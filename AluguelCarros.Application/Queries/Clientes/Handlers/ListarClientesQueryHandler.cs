using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Domain.Entities;
using MediatR;
using AluguelCarros.Application.Queries.Clientes.Queries;
using AluguelCarros.Domain.Repositories;

namespace AluguelCarros.Application.Queries.Clientes.Handlers
{
    public class ListarClientesQueryHandler : IRequestHandler<ListarClientesQuery, List<Cliente>>
    {
        private readonly IClienteRepository _repository;

        public ListarClientesQueryHandler(IClienteRepository clienteRepository)
        {
            _repository = clienteRepository;
        }

        public async Task<List<Cliente>> Handle(ListarClientesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
