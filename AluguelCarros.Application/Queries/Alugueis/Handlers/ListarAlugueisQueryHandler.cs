using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Infrastructure.Data;
using AluguelCarros.Infrastructure.Entities;
using MediatR;
using AluguelCarros.Application.Queries.Alugueis.Queries;

namespace AluguelCarros.Application.Queries.Alugueis.Handlers
{
    public class ListarAlugueisQueryHandler : IRequestHandler<ListarAlugueisQuery, List<Aluguel>>
    {
        private readonly AluguelRepository repository;

        public ListarAlugueisQueryHandler(AppDbContext context)
        {
            repository = new(context);
        }

        async Task<List<Aluguel>> IRequestHandler<ListarAlugueisQuery, List<Aluguel>>.Handle(ListarAlugueisQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllAsync(cancellationToken);
        }
    }
}
