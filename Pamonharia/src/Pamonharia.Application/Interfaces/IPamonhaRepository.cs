using Pamonharia.Domain.Entities;

namespace Pamonharia.Application.Interfaces
{
    public interface IPamonhaRepository
    {
        Task<Pamonha?> GetByIdAsync(int id);
        Task<IEnumerable<Pamonha>> GetAllAsync();
        Task AddAsync(Pamonha pamonha);
        Task UpdateAsync(Pamonha pamonha);
        Task DeleteAsync(int id);
    }
}