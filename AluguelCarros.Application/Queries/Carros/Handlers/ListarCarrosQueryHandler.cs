using AluguelCarros.Infrastructure.Data;
using AluguelCarros.Infrastructure.Entities;
using MediatR;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Application.Queries.Carros.Queries;
using AluguelCarros.Infrastructure.Repositories;

namespace AluguelCarros.Application.Queries.Carros.Handlers
{
    public class ListarCarrosQueryHandler : IRequestHandler<ListarCarrosQuery, List<Carro>>
    {
        private readonly CarroRepository _repository;

        public ListarCarrosQueryHandler(AppDbContext context)
        {
            _repository = new(context);
        }

        public async Task<List<Carro>> Handle(ListarCarrosQuery request, CancellationToken cancellationToken)
        {
            if (!request.Disponivel.HasValue)
                return await _repository.GetAllAsync(cancellationToken);

            return await _repository.GetByDisponibilidadeAsync(request.Disponivel.Value);
        }
    }
}
