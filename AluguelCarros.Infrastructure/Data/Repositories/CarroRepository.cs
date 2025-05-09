using AluguelCarros.Infrastructure.Entities;
using AluguelCarros.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarros.Infrastructure.Data.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly AppDbContext _context;

        public CarroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Carro?> GetByIdAsync(Guid id)
        {
            return await _context.Carros.FindAsync(id);
        }

        public async Task<IEnumerable<Carro>> GetDisponiveisAsync()
        {
            return await _context.Carros.Where(c => c.Disponivel).ToListAsync();
        }

        public async Task AddAsync(Carro carro)
        {
            await _context.Carros.AddAsync(carro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Carro carro)
        {
            _context.Carros.Update(carro);
            await _context.SaveChangesAsync();
        }
    }
}
