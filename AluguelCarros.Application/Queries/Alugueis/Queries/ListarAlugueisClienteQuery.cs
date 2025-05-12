using AluguelCarros.Domain.Entities;
using MediatR;

namespace AluguelCarros.Application.Queries.Alugueis.Queries
{
    public class ListarAlugueisClienteQuery : IRequest<List<Aluguel>>
    {
        public Guid ClienteId { get; set; }

        public ListarAlugueisClienteQuery(Guid clienteId)
        {
            ClienteId = clienteId;
        }
    }
}
