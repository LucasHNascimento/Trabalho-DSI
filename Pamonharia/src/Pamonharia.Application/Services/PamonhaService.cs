using Pamonharia.Application.Interfaces;
using Pamonharia.Application.ViewModels;
using Pamonharia.Domain.Entities;

namespace Pamonharia.Application.Services
{
    public class PamonhaService : IPamonhaService
    {
        private readonly IPamonhaRepository _repository;
        // Aqui você poderia injetar um Mapper (ex: AutoMapper)

        public PamonhaService(IPamonhaRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(PamonhaViewModel viewModel)
        {
            // Mapeamento manual de ViewModel para Entidade
            var pamonha = new Pamonha(viewModel.Sabor, viewModel.Preco);
            await _repository.AddAsync(pamonha);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PamonhaViewModel>> GetAllAsync()
        {
            var pamonhas = await _repository.GetAllAsync();

            // Mapeamento manual de Entidade para ViewModel
            return pamonhas.Select(p => new PamonhaViewModel
            {
                Id = p.Id,
                Sabor = p.Sabor,
                Preco = p.Preco,
                DataProducao = p.DataProducao
            });
        }

        public async Task<PamonhaViewModel?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null) return null;

            return new PamonhaViewModel
            {
                Id = p.Id,
                Sabor = p.Sabor,
                Preco = p.Preco,
                DataProducao = p.DataProducao
            };
        }

        public async Task UpdateAsync(PamonhaViewModel viewModel)
        {
            var pamonha = await _repository.GetByIdAsync(viewModel.Id);
            if (pamonha != null)
            {
                pamonha.Atualizar(viewModel.Sabor, viewModel.Preco);
                await _repository.UpdateAsync(pamonha);
            }
        }
    }
}