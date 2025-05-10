using AluguelCarros.Infrastructure.Entities;
using MediatR;

namespace AluguelCarros.Application.Queries
{
    public class ListarCarrosQuery : IRequest<List<Carro>>
    {
    }
}
