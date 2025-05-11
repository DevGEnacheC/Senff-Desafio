using AluguelCarros.Infrastructure.Entities;
using MediatR;

namespace AluguelCarros.Application.Queries.Carros.Queries
{
    public class ListarCarrosQuery : IRequest<List<Carro>>
    {
        public bool? Disponivel { get; set; }

        public ListarCarrosQuery(bool? disponivel)
        {
            Disponivel = disponivel;
        }
    }
}
