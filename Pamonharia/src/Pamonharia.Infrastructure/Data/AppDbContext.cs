using Microsoft.EntityFrameworkCore;
using Pamonharia.Domain.Entities;

namespace Pamonharia.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pamonha> Pamonhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações (ex: definir Pamonha.Id como chave primária)
            modelBuilder.Entity<Pamonha>().HasKey(p => p.Id);

            // O EF Core 8+ consegue mapear propriedades privadas
            modelBuilder.Entity<Pamonha>().Property(p => p.Sabor);
            modelBuilder.Entity<Pamonha>().Property(p => p.Preco).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Pamonha>().Property(p => p.DataProducao);
        }
    }
}