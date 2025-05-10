using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluguelCarros.Infrastructure.Entities;

namespace AluguelCarros.Infrastructure.Repositories
{
    public interface IAluguelRepository
    {
        Task<Aluguel?> GetByIdAsync(Guid id);
        Task AddAsync(Aluguel aluguel);
        Task UpdateAsync(Aluguel aluguel);
        Task<List<Aluguel>> GetAllAsync(CancellationToken cancellationToken);
    }
}
