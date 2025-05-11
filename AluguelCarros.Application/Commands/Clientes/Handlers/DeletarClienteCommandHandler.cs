using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Infrastructure.Data;
using MediatR;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Application.Events.Clientes.Events;

namespace AluguelCarros.Application.Commands.Clientes.Commands
{
    public class DeletarClienteCommandHandler : IRequestHandler<DeletarClienteCommand, Guid>
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly AluguelRepository _aluguelRepository;
        private readonly IMediator _mediator;

        public DeletarClienteCommandHandler(AppDbContext context, IMediator mediator)
        {
            _aluguelRepository = new(context);
            _clienteRepository = new(context);
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
