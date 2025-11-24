using MapsterMapper; 
using Pamonharia.Application.Interfaces;
using Pamonharia.Application.ViewModels;
using Pamonharia.Domain.Entities;

namespace Pamonharia.Application.Services
{
    public class PamonhaService : IPamonhaService
    {
        private readonly IPamonhaRepository _repository;
        private readonly IMapper _mapper; 

        public PamonhaService(IPamonhaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(PamonhaViewModel viewModel)
        {
            // Agora passamos o CategoriaId corretamente
            var pamonha = new Pamonha(viewModel.Sabor, viewModel.Preco, viewModel.CategoriaId);
            await _repository.AddAsync(pamonha);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PamonhaViewModel>> GetAllAsync()
        {
            var pamonhas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PamonhaViewModel>>(pamonhas);
        }

        public async Task<PamonhaViewModel?> GetByIdAsync(int id)
        {
            var pamonha = await _repository.GetByIdAsync(id);
            if (pamonha == null) return null;
            return _mapper.Map<PamonhaViewModel>(pamonha);
        }

        public async Task UpdateAsync(PamonhaViewModel viewModel)
        {
            var pamonha = await _repository.GetByIdAsync(viewModel.Id);
            if (pamonha != null)
            {
                pamonha.Atualizar(viewModel.Sabor, viewModel.Preco, viewModel.CategoriaId);
                await _repository.UpdateAsync(pamonha);
            }
        }
    }
}