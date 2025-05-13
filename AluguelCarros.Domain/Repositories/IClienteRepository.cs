using AluguelCarros.Domain.Entities;

namespace AluguelCarros.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetByIdAsync(Guid id);
        Task<List<Cliente>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente, CancellationToken cancellationToken);
        Task<bool> ExistsByCPFAsync(string cpf, CancellationToken cancellationToken);
        Task<bool> ExistsByCNHAsync(string cnh, CancellationToken cancellationToken);
    }
}
