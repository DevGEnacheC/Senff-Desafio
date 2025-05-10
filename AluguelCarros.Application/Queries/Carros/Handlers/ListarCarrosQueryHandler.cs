using AluguelCarros.Infrastructure.Data;
using AluguelCarros.Infrastructure.Entities;
using MediatR;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Application.Queries.Carros.Queries;

namespace AluguelCarros.Application.Queries.Carros.Handlers
{
    public class ListarCarrosQueryHandler : IRequestHandler<ListarCarrosQuery, List<Carro>>
    {
        private readonly CarroRepository repository;

        public ListarCarrosQueryHandler(AppDbContext context)
        {
            repository = new(context);
        }

        public async Task<List<Carro>> Handle(ListarCarrosQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllAsync(cancellationToken);
        }
    }
}
