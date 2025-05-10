using AluguelCarros.Infrastructure.Entities;
using MediatR;

namespace AluguelCarros.Application.Queries.Clientes.Queries
{
    public class ListarClientesQuery : IRequest<List<Cliente>>
    {
    }
}
