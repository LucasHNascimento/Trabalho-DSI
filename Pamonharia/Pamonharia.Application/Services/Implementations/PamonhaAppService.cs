using AutoMapper;
using Pamonharia.Application.Services.Interfaces;
using Pamonharia.Application.ViewModels;
using Pamonharia.Domain.Entities;
using Pamonharia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pamonharia.Application.Services.Implementations
{
    public class PamonhaAppService : IPamonhaAppService
    {
        private readonly IPamonhaRepository _pamonhaRepository;
        private readonly IMapper _mapper;

        // Injeção de Dependências (IoC)
        public PamonhaAppService(IPamonhaRepository pamonhaRepository, IMapper mapper)
        {
            _pamonhaRepository = pamonhaRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(PamonhaViewModel pamonhaViewModel)
        {
            // Mapeia ViewModel para Entidade
            //var pamonha = _mapper.Map<Pamonha>(pamonhaViewModel);
            
            // Usando o construtor da entidade para garantir regras de negócio
            var pamonha = new Pamonha(
                pamonhaViewModel.Sabor, 
                pamonhaViewModel.Preco, 
                pamonhaViewModel.ComQueijo);

            await _pamonhaRepository.AddAsync(pamonha);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _pamonhaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PamonhaViewModel>> GetAllAsync()
        {
            var pamonhas = await _pamonhaRepository.GetAllAsync();
            // Mapeia Entidade para ViewModel
            return _mapper.Map<IEnumerable<PamonhaViewModel>>(pamonhas);
        }

        public async Task<PamonhaViewModel> GetByIdAsync(Guid id)
        {
            var pamonha = await _pamonhaRepository.GetByIdAsync(id);
            return _mapper.Map<PamonhaViewModel>(pamonha);
        }

        public async Task UpdateAsync(PamonhaViewModel pamonhaViewModel)
        {
            var pamonha = await _pamonhaRepository.GetByIdAsync(pamonhaViewModel.Id);
            
            if (pamonha == null)
                throw new ApplicationException("Pamonha não encontrada.");

            // Usa o método da entidade para atualizar
            pamonha.Atualizar(
                pamonhaViewModel.Sabor, 
                pamonhaViewModel.Preco, 
                pamonhaViewModel.ComQueijo);

            await _pamonhaRepository.UpdateAsync(pamonha);
        }
    }
}