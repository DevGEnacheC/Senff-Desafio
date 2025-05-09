using AluguelCarros.Infrastructure.Entities;

namespace AluguelCarros.Infrastructure.Repositories
{
    public interface ICarroRepository
    {
        Task<Carro?> GetByIdAsync(Guid id);
        Task<IEnumerable<Carro>> GetDisponiveisAsync();
        Task AddAsync(Carro carro);
        Task UpdateAsync(Carro carro);
    }
}
