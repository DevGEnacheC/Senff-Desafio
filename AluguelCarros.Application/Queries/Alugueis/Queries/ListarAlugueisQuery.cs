using AluguelCarros.Infrastructure.Entities;
using MediatR;

namespace AluguelCarros.Application.Queries.Alugueis.Queries
{
    public class ListarAlugueisQuery : IRequest<List<Aluguel>>
    {
    }
}
