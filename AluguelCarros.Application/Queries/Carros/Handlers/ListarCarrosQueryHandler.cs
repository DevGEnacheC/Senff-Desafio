using AluguelCarros.Domain.Entities;
using MediatR;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Application.Queries.Carros.Queries;
using AluguelCarros.Domain.Repositories;

namespace AluguelCarros.Application.Queries.Carros.Handlers
{
    public class ListarCarrosQueryHandler : IRequestHandler<ListarCarrosQuery, List<Carro>>
    {
        private readonly ICarroRepository _repository;

        public ListarCarrosQueryHandler(ICarroRepository carroRepository)
        {
            _repository = carroRepository;
        }

        public async Task<List<Carro>> Handle(ListarCarrosQuery request, CancellationToken cancellationToken)
        {
            if (!request.Disponivel.HasValue)
                return await _repository.GetAllAsync(cancellationToken);

            return await _repository.GetByDisponibilidadeAsync(request.Disponivel.Value);
        }
    }
}
