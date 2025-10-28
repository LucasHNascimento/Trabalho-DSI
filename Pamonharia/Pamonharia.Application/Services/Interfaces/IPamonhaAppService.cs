using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pamonharia.Application.ViewModels;

namespace Pamonharia.Application.Services.Interfaces
{
    // Interface do Serviço de Aplicação (orquestrador)
    public interface IPamonhaAppService
    {
        Task<PamonhaViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<PamonhaViewModel>> GetAllAsync();
        Task AddAsync(PamonhaViewModel pamonhaViewModel);
        Task UpdateAsync(PamonhaViewModel pamonhaViewModel);
        Task DeleteAsync(Guid id);
    }
}