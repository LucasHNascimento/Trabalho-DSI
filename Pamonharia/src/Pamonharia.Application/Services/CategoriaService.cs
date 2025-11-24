using MapsterMapper;
using Pamonharia.Application.Interfaces;
using Pamonharia.Application.ViewModels;
using Pamonharia.Domain.Entities;

namespace Pamonharia.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoriaViewModel viewModel)
        {
            var categoria = _mapper.Map<Categoria>(viewModel);
            await _repository.AddAsync(categoria);
        }

        public async Task DeleteAsync(int id)
        {
            // Nota: O repositório deve implementar lógica para deletar. 
            // Se não tiver, adicione um método DeleteAsync no ICategoriaRepository/CategoriaRepository similar ao PamonhaRepository.
            // Assumindo que você adicionará ou já tem um método genérico ou específico de delete.
            // Para simplificar aqui, vou assumir que você vai adicionar o DeleteAsync no repositório de Categoria.
             await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoriaViewModel>> GetAllAsync()
        {
            var categorias = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(categorias);
        }

        public async Task<CategoriaViewModel?> GetByIdAsync(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);
            if (categoria == null) return null;
            return _mapper.Map<CategoriaViewModel>(categoria);
        }

        public async Task UpdateAsync(CategoriaViewModel viewModel)
        {
            var categoria = await _repository.GetByIdAsync(viewModel.Id);
            if (categoria != null)
            {
                categoria.Atualizar(viewModel.Nome, viewModel.Descricao);
                await _repository.UpdateAsync(categoria);
            }
        }
    }
}