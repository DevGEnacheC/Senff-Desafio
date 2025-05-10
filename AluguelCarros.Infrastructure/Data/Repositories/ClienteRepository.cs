using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluguelCarros.Infrastructure.Entities;
using AluguelCarros.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarros.Infrastructure.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<List<Cliente>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Clientes.ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsByCPFAsync(string cpf, CancellationToken cancellationToken)
        {
            return await _context.Clientes.AnyAsync(c => c.CPF == cpf, cancellationToken);
        }
    }
}
