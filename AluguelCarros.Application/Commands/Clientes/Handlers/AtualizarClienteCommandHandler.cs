using AluguelCarros.Application.Commands.Clientes.Commands;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Infrastructure.Data;
using MediatR;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Application.Events.Clientes.Events;

namespace AluguelCarros.Application.Commands.Clientes.Handlers
{   

    public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand, Guid>
    {
        private readonly ClienteRepository _repository;
        private readonly IMediator _mediator;

        public AtualizarClienteCommandHandler(AppDbContext context, IMediator mediator)
        {
            _repository = new(context);
            _mediator = mediator;
        }


        public async Task<Guid> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id);

            if(cliente == null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Id", "O clientes especificado não existe.")
                ]);
            }

            if(cliente.CPF != request.CPF)
            {
                if (await _repository.ExistsByCPFAsync(request.CPF, cancellationToken))
                {
                    throw new FluentValidationException(
                    [
                        new FluentValidation.Results.ValidationFailure("CPF", "O CPF já está em uso.")
                    ]);
                }
            }

            cliente.Update(request.Nome, request.CPF);

            await _repository.UpdateAsync(cliente);

            var evento = new ClienteAtualizadoEvent(cliente.Id, cliente.Nome, cliente.CPF);
            await _mediator.Publish(evento, cancellationToken);

            return cliente.Id;
        }
    }
}
