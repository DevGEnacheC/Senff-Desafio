using AluguelCarros.Application.Events;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Infrastructure.Data;
using AluguelCarros.Infrastructure.Entities;
using MediatR;

namespace AluguelCarros.Application.Commands
{
    public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, Guid>
    {
        private readonly ClienteRepository repository;
        private readonly IMediator _mediator;

        public CriarClienteCommandHandler(AppDbContext context, IMediator mediator)
        {
            repository = new(context);
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            if (await repository.ExistsByCPFAsync(request.CPF, cancellationToken))
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("CPF", "O CPF já está em uso.")
                ]);
            }

            var cliente = new Cliente(request.Nome, request.CPF);

            await repository.AddAsync(cliente);

            var evento = new ClienteCriadoEvent(cliente.Id, cliente.Nome, cliente.CPF);
            await _mediator.Publish(evento, cancellationToken);

            return cliente.Id;
        }
    }
}
