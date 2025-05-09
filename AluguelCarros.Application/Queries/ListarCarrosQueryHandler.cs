using AluguelCarros.Infrastructure.Data;
using AluguelCarros.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace AluguelCarros.Application.Queries
{
    public class ListarCarrosQueryHandler : IRequestHandler<ListarCarrosQuery, List<Carro>>
    {
        private readonly AppDbContext _context;

        public ListarCarrosQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Carro>> Handle(ListarCarrosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Carros.ToListAsync(cancellationToken);
        }
    }
}
