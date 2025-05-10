using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Infrastructure.Data;
using AluguelCarros.Infrastructure.Entities;
using MediatR;
using AluguelCarros.Application.Queries.Clientes.Queries;

namespace AluguelCarros.Application.Queries.Clientes.Handlers
{
    public class ListarClientesQueryHandler : IRequestHandler<ListarClientesQuery, List<Cliente>>
    {
        private readonly ClienteRepository repository;

        public ListarClientesQueryHandler(AppDbContext context)
        {
            repository = new(context);
        }

        public async Task<List<Cliente>> Handle(ListarClientesQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllAsync(cancellationToken);
        }
    }
}
