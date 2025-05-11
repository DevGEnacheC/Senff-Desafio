using AluguelCarros.Domain.Entities;

namespace AluguelCarros.Domain.Repositories
{
    public interface IAluguelRepository
    {
        Task<Aluguel?> GetByIdAsync(Guid id);
        Task AddAsync(Aluguel aluguel);
        Task UpdateAsync(Aluguel aluguel);
        Task<List<Aluguel>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> CheckCarAvailabilityAsync(Guid carroId, CancellationToken cancellationToken);
        Task<bool> CheckClienteAvailabilityAsync(Guid cleinteId, CancellationToken cancellationToken);
    }
}
