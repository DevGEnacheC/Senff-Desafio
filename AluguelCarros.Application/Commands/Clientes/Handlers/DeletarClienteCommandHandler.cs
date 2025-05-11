using AluguelCarros.Infrastructure.Data.Repositories;
using MediatR;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Application.Events.Clientes.Events;
using AluguelCarros.Domain.Repositories;

namespace AluguelCarros.Application.Commands.Clientes.Commands
{
    public class DeletarClienteCommandHandler : IRequestHandler<DeletarClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IMediator _mediator;

        public DeletarClienteCommandHandler(
            IClienteRepository clienteRepository,
            IAluguelRepository aluguelRepository,
            IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _aluguelRepository = aluguelRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
        {
            var carro = await _clienteRepository.GetByIdAsync(request.Id);

            if (carro == null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Id", "O cliente especificado não existe.")
                ]);
            }

            bool temAlugueisVinculados = await _aluguelRepository.CheckClienteAvailabilityAsync(request.Id, cancellationToken);
            if (temAlugueisVinculados)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Id", "O cliente não pode ser deletado pois possui aluguéis vinculados.")
                ]);
            }

            await _clienteRepository.DeleteAsync(carro, cancellationToken);

            var evento = new ClienteDeletadoEvent(carro.Id);
            await _mediator.Publish(evento, cancellationToken);

            return carro.Id;
        }
    }
}
