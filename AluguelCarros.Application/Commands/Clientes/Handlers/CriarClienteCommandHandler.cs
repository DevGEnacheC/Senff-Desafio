using AluguelCarros.Application.Events.Clientes.Events;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Domain.Entities;
using MediatR;
using AluguelCarros.Application.Commands.Clientes.Commands;
using AluguelCarros.Domain.Repositories;

namespace AluguelCarros.Application.Commands.Clientes.Handlers
{
    public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, Guid>
    {
        private readonly IClienteRepository _repository;
        private readonly IMediator _mediator;

        public CriarClienteCommandHandler(IClienteRepository clienteRepository, IMediator mediator)
        {
            _repository = clienteRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.ExistsByCPFAsync(request.CPF, cancellationToken))
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("CPF", "O CPF já está em uso.")
                ]);
            }

            if (await _repository.ExistsByCNHAsync(request.CNH, cancellationToken))
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("CNH", "O CNH já está em uso.")
                ]);
            }

            var cliente = new Cliente(request.Nome, request.CPF, request.CNH);

            await _repository.AddAsync(cliente);

            var evento = new ClienteCriadoEvent(cliente.Id, cliente.Nome, cliente.CPF, cliente.CNH);
            await _mediator.Publish(evento, cancellationToken);

            return cliente.Id;
        }
    }
}
