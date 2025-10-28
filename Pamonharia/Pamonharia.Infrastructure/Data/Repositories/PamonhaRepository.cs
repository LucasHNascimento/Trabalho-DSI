using Microsoft.EntityFrameworkCore;
using Pamonharia.Domain.Entities;
using Pamonharia.Domain.Interfaces;
using Pamonharia.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pamonharia.Infrastructure.Data.Repositories
{
    // Implementação concreta do Repositório
    public class PamonhaRepository : IPamonhaRepository
    {
        private readonly PamonhariaContext _context;

        public PamonhaRepository(PamonhariaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pamonha pamonha)
        {
            _context.Pamonhas.Add(pamonha);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var pamonha = await _context.Pamonhas.FindAsync(id);
            if (pamonha != null)
            {
                _context.Pamonhas.Remove(pamonha);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Pamonha>> GetAllAsync()
        {
            return await _context.Pamonhas.AsNoTracking().ToListAsync();
        }

        public async Task<Pamonha> GetByIdAsync(Guid id)
        {
            return await _context.Pamonhas.FindAsync(id);
        }

        public async Task UpdateAsync(Pamonha pamonha)
        {
            _context.Entry(pamonha).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}