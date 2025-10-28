using Microsoft.EntityFrameworkCore;
using Pamonharia.Domain.Entities;

namespace Pamonharia.Infrastructure.Data.Context
{
    public class PamonhariaContext : DbContext
    {
        public PamonhariaContext(DbContextOptions<PamonhariaContext> options)
            : base(options)
        {
        }

        public DbSet<Pamonha> Pamonhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações (Fluent API)
            modelBuilder.Entity<Pamonha>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Sabor).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Preco).IsRequired().HasColumnType("decimal(18,2)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}