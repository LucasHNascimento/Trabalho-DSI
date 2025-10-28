using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pamonharia.Domain.Entities;

namespace Pamonharia.Domain.Interfaces
{
    // Contrato de persistência para a Entidade Pamonha.
    // A camada de Domínio define a *necessidade*, 
    // a Infraestrutura a *implementa*.
    public interface IPamonhaRepository
    {
        Task<Pamonha> GetByIdAsync(Guid id);
        Task<IEnumerable<Pamonha>> GetAllAsync();
        Task AddAsync(Pamonha pamonha);
        Task UpdateAsync(Pamonha pamonha);
        Task DeleteAsync(Guid id);
    }
}