using AluguelCarros.Infrastructure.Entities;

namespace AluguelCarros.Infrastructure.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetByIdAsync(Guid id);
        Task AddAsync(Cliente cliente);
        Task<List<Cliente>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> ExistsByCPFAsync(string cpf, CancellationToken cancellationToken);
    }
}
