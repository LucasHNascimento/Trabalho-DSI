using Microsoft.EntityFrameworkCore;
using Pamonharia.Application.Interfaces;
using Pamonharia.Domain.Entities;

namespace Pamonharia.Infrastructure.Data.Repositories
{
    public class PamonhaRepository : IPamonhaRepository
    {
        private readonly AppDbContext _context;

        public PamonhaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pamonha pamonha)
        {
            await _context.Pamonhas.AddAsync(pamonha);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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

        public async Task<Pamonha?> GetByIdAsync(int id)
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