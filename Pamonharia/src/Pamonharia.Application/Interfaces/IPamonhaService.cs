using Pamonharia.Application.ViewModels;

namespace Pamonharia.Application.Interfaces
{
    public interface IPamonhaService
    {
        Task<PamonhaViewModel?> GetByIdAsync(int id);
        Task<IEnumerable<PamonhaViewModel>> GetAllAsync();
        Task CreateAsync(PamonhaViewModel viewModel);
        Task UpdateAsync(PamonhaViewModel viewModel);
        Task DeleteAsync(int id);
    }
}