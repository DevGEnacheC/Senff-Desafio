using AluguelCarros.Domain.Entities;
using AluguelCarros.Domain.Repositories;
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

        public async Task<List<Carro>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Carros.ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsByPlacaAsync(string placa, CancellationToken cancellationToken)
        {
            return await _context.Carros.AnyAsync(c => c.Placa == placa, cancellationToken);
        }

        public async Task<bool> GetDisponivel(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Carros.AnyAsync(
                   c => c.Id == id && c.Disponivel, cancellationToken);
        }

        public async Task<List<Carro>> GetByDisponibilidadeAsync(bool disponivel)
        {
            return await _context.Carros
            .Where(c => c.Disponivel == disponivel)
            .ToListAsync();
        }

        public async Task DeleteAsync(Carro carro, CancellationToken cancellationToken)
        {
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
