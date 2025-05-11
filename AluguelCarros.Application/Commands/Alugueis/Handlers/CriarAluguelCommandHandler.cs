using AluguelCarros.Application.Exceptions;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Infrastructure.Data;
using AluguelCarros.Infrastructure.Entities;
using MediatR;
using AluguelCarros.Application.Commands.Alugueis.Commands;
using AluguelCarros.Application.Events.Alugueis.Events;

namespace AluguelCarros.Application.Commands.Alugueis.Handlers
{
    public class CriarAluguelCommandHandler : IRequestHandler<CriarAluguelCommand, Guid>
    {
        private readonly AluguelRepository _aluguelRepository;
        private readonly CarroRepository _carroRepository;
        private readonly ClienteRepository _clienteRepository;

        private readonly IMediator _mediator;

        public CriarAluguelCommandHandler(AppDbContext context, IMediator mediator)
        {
            _aluguelRepository = new(context);
            _carroRepository = new(context);
            _clienteRepository = new(context);
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarAluguelCommand request, CancellationToken cancellationToken)
        {   
            var carro = await _carroRepository.GetByIdAsync(request.CarroId);
            
            if (carro == null) 
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("CarroId", "O carro especificado não existe.")
                ]);
            }

            var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId);
            if (cliente == null)
            {
               throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("ClienteId", "O cliente especificado não existe.")
                ]);
            }

            if (!carro.Disponivel)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("CarroId", "O carro não está disponivel.")
                ]);
            }

            var aluguel = new Aluguel(
                request.CarroId, 
                request.ClienteId, 
                request.DataInicio, request.DataFim,
                request.ValorAluguel);

            await _aluguelRepository.AddAsync(aluguel);

            carro.Reservar();

            await _carroRepository.UpdateAsync(carro);

            var evento = new AluguelCriadoEvent(aluguel.Id, 
                                                aluguel.CarroId, aluguel.ClienteId,
                                                aluguel.DataInicio, aluguel.DataFim,
                                                aluguel.ValorAluguel);
            await _mediator.Publish(evento, cancellationToken);

            return aluguel.Id;
        }
    }
}
