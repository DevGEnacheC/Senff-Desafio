using AluguelCarros.Domain.Entities;
using AluguelCarros.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarros.Infrastructure.Data.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private readonly AppDbContext _context;

        public AluguelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Aluguel aluguel)
        {
            await _context.Alugueis.AddAsync(aluguel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Aluguel aluguel)
        {
            _context.Alugueis.Update(aluguel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Aluguel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Alugueis.ToListAsync(cancellationToken);
        }

        public async Task<Aluguel?> GetByIdAsync(Guid id)
        {
            return await _context.Alugueis.FindAsync(id);
        }

        public async Task<bool> CheckCarAvailabilityAsync(Guid carroId, CancellationToken cancellationToken)
        {
            return await _context.Alugueis.AnyAsync(c => c.CarroId == carroId, cancellationToken);
        }

        public async Task<bool> CheckClienteAvailabilityAsync(Guid clienteId, CancellationToken cancellationToken)
        {
            return await _context.Alugueis.AnyAsync(c => c.ClienteId == clienteId, cancellationToken);
        }

        public async Task<List<Aluguel>> GetByCarro(Guid carroId)
        {
            return await _context.Alugueis.Where(c => c.CarroId == carroId).ToListAsync();
        }

        public async Task<List<Aluguel>> GetByCliente(Guid clienteId)
        {
            return await _context.Alugueis.Where(c => c.ClienteId == clienteId).ToListAsync();
        }
    }
}
