using Microsoft.EntityFrameworkCore;
using Pamonharia.Application.Interfaces;
using Pamonharia.Domain.Entities;
using Pamonharia.Infrastructure.Data;

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
            // INCLUDE: Traz os dados da Categoria junto com a Pamonha
            return await _context.Pamonhas
                .Include(p => p.Categoria) 
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pamonha?> GetByIdAsync(int id)
        {
            return await _context.Pamonhas
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Pamonha pamonha)
        {
            _context.Entry(pamonha).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}