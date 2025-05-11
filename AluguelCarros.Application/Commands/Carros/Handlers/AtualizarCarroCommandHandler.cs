using AluguelCarros.Application.Commands.Carros.Commands;
using AluguelCarros.Application.Events.Carros.Events;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Infrastructure.Data.Repositories;
using MediatR;
using AluguelCarros.Domain.Repositories;

namespace AluguelCarros.Application.Commands.Carros.Handlers
{
    public class AtualizarCarroCommandHandler : IRequestHandler<AtualizarCarroCommand, Guid>
    {
        private readonly ICarroRepository _repository;
        private readonly IMediator _mediator;

        public AtualizarCarroCommandHandler(ICarroRepository carroRepository, IMediator mediator)
        {
            _repository = carroRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(AtualizarCarroCommand request, CancellationToken cancellationToken)
        {
            var carro = await _repository.GetByIdAsync(request.Id);

            if (carro == null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Id", "O carro especificado não existe.")
                ]);
            }

            // Se a Placa for alterada
            if (carro.Placa != request.Placa)
            {
                if (await _repository.ExistsByPlacaAsync(request.Placa, cancellationToken))
                {
                    throw new FluentValidationException(
                    [
                        new FluentValidation.Results.ValidationFailure("Placa", "A placa já está em uso.")
                    ]);
                }
            }

            if (carro.Disponivel != request.Disponivel)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Disponivel", 
                        "Só é possivel alterar a disponibilidade do carro atráves de uma transação.")
                ]);
            }

            carro.Update(request.Marca, request.Modelo, request.Ano, request.Placa);

            await _repository.UpdateAsync(carro);

            var evento = new CarroAtualizadoEvent(carro.Id, carro.Marca, carro.Modelo, carro.Ano, carro.Placa, carro.Disponivel);
            await _mediator.Publish(evento, cancellationToken);

            return carro.Id;
        }
    }
}
