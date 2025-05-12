using AluguelCarros.Application.Exceptions;
using AluguelCarros.Domain.Repositories;
using AluguelCarros.Domain.Entities;
using MediatR;
using AluguelCarros.Application.Commands.Alugueis.Commands;
using AluguelCarros.Application.Events.Alugueis.Events;
using AluguelCarros.Infrastructure.Data.Repositories;

namespace AluguelCarros.Application.Commands.Alugueis.Handlers
{
    public class CriarAluguelCommandHandler : IRequestHandler<CriarAluguelCommand, Guid>
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly ICarroRepository _carroRepository;
        private readonly IClienteRepository _clienteRepository;

        private readonly IMediator _mediator;

        public CriarAluguelCommandHandler(
            IAluguelRepository aluguelRepository,
            ICarroRepository carroRepository,
            IClienteRepository clienteRepository,
            IMediator mediator)
        {
            _aluguelRepository = aluguelRepository;
            _carroRepository = carroRepository;
            _clienteRepository = clienteRepository;
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
                request.DataInicio, request.DataFim);

            await _aluguelRepository.AddAsync(aluguel);

            carro.Reservar();

            await _carroRepository.UpdateAsync(carro);

            var evento = new AluguelCriadoEvent(aluguel.Id, 
                                                aluguel.CarroId, aluguel.ClienteId,
                                                aluguel.DataInicio, aluguel.DataFim);
            await _mediator.Publish(evento, cancellationToken);

            return aluguel.Id;
        }
    }
}
