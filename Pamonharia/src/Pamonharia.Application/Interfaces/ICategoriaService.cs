using Pamonharia.Application.ViewModels;

namespace Pamonharia.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaViewModel>> GetAllAsync();
        Task<CategoriaViewModel?> GetByIdAsync(int id);
        Task CreateAsync(CategoriaViewModel viewModel);
        Task UpdateAsync(CategoriaViewModel viewModel);
        Task DeleteAsync(int id);
    }
}