
using AluguelCarros.Domain.Entities;
using MediatR;
using AluguelCarros.Domain.Repositories;
using AluguelCarros.Application.Queries.Alugueis.Queries;

namespace AluguelCarros.Application.Queries.Alugueis.Handlers
{
    public class ListarAlugueisQueryHandler : IRequestHandler<ListarAlugueisQuery, List<Aluguel>>
    {
        private readonly IAluguelRepository _repository;

        public ListarAlugueisQueryHandler(IAluguelRepository aluguelRepository)
        {
            _repository = aluguelRepository;
        }

        public async Task<List<Aluguel>> Handle(ListarAlugueisQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
