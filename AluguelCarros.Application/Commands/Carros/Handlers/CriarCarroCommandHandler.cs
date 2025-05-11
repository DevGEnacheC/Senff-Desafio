using AluguelCarros.Infrastructure.Entities;
using AluguelCarros.Infrastructure.Data;
using MediatR;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Application.Commands.Carros.Commands;
using AluguelCarros.Application.Events.Carros.Events;

namespace AluguelCarros.Application.Commands.Carros.Handlers
{
    public class CriarCarroCommandHandler : IRequestHandler<CriarCarroCommand, Guid>
    {
        private readonly CarroRepository repository;
        private readonly IMediator _mediator;

        public CriarCarroCommandHandler(AppDbContext context, IMediator mediator)
        {
            repository = new(context);
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarCarroCommand request, CancellationToken cancellationToken)
        {
            if (await repository.ExistsByPlacaAsync(request.Placa, cancellationToken))
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Placa", "A placa já está em uso.")
                ]);
            }

            var carro = new Carro(request.Marca, request.Modelo, request.Ano, request.Placa);
            
            await repository.AddAsync(carro);

            var evento = new CarroCriadoEvent(carro.Id, carro.Marca, carro.Modelo, carro.Ano, carro.Placa);
            await _mediator.Publish(evento, cancellationToken);

            return carro.Id;
        }
    }
}
