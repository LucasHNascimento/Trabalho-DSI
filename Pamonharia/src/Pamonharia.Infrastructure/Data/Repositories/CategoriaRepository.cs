using Microsoft.EntityFrameworkCore;
using Pamonharia.Application.Interfaces;
using Pamonharia.Domain.Entities;
using Pamonharia.Infrastructure.Data;

namespace Pamonharia.Infrastructure.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Categoria>> GetAllAsync() => 
            await _context.Categorias.AsNoTracking().ToListAsync();
            
        public async Task<Categoria?> GetByIdAsync(int id) =>
            await _context.Categorias.FindAsync(id);

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}