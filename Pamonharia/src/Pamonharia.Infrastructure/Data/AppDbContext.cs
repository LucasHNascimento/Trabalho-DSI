using Microsoft.EntityFrameworkCore;
using Pamonharia.Domain.Entities;

namespace Pamonharia.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pamonha> Pamonhas { get; set; }
        public DbSet<Categoria> Categorias { get; set; } // Adicionado DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pamonha>().HasKey(p => p.Id);
            modelBuilder.Entity<Pamonha>().Property(p => p.Preco).HasColumnType("decimal(18,2)");

            // Configuração do Relacionamento 1:N
            modelBuilder.Entity<Pamonha>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Pamonhas)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict); // Impede deletar categoria em uso
        }
    }
}