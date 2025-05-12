using AluguelCarros.Domain.Entities;
using MediatR;

namespace AluguelCarros.Application.Queries.Alugueis.Queries
{
    public class ListarAlugueisCarroQuery : IRequest<List<Aluguel>>
    {
        public Guid CarroId { get; set; }

        public ListarAlugueisCarroQuery(Guid carroId)
        {
            CarroId = carroId;
        }
    }
}
