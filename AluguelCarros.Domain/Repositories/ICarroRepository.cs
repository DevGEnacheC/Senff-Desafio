using AluguelCarros.Infrastructure.Entities;

namespace AluguelCarros.Infrastructure.Repositories
{
    public interface ICarroRepository
    {
        Task<Carro?> GetByIdAsync(Guid id);
        Task<IEnumerable<Carro>> GetDisponiveisAsync();
        Task AddAsync(Carro carro);
        Task UpdateAsync(Carro carro);
        Task<List<Carro>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> ExistsByPlacaAsync(string placa, CancellationToken cancellationToken);
        Task<bool> GetDisponivel(Guid id, CancellationToken cancellationToken);
        Task<List<Carro>> GetByDisponibilidadeAsync(bool disponivel);
        Task DeleteAsync(Carro carro, CancellationToken cancellationToken);
    }
}
