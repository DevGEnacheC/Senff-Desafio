using AluguelCarros.Infrastructure.Entities;

namespace AluguelCarros.Infrastructure.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetByIdAsync(Guid id);
        Task<List<Cliente>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente, CancellationToken cancellationToken);
        Task<bool> ExistsByCPFAsync(string cpf, CancellationToken cancellationToken);
    }
}
