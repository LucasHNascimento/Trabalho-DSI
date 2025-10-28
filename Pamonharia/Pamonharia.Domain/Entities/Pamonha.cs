using System;
using System.ComponentModel.DataAnnotations;

namespace Pamonharia.Domain.Entities
{
    // Esta é a nossa Entidade de Domínio (DDD Aggregate Root)
    public class Pamonha
    {
        [Key]
        public Guid Id { get; private set; }
        public string Sabor { get; private set; }
        public decimal Preco { get; private set; }
        public bool ComQueijo { get; private set; }
        public DateTime DataProducao { get; private set; }

        // Construtor para o EF Core
        protected Pamonha() { }

        // Construtor para criar uma nova pamonha
        public Pamonha(string sabor, decimal preco, bool comQueijo)
        {
            Id = Guid.NewGuid();
            Sabor = sabor;
            Preco = preco;
            ComQueijo = comQueijo;
            DataProducao = DateTime.UtcNow;
            // Validações de domínio poderiam ir aqui
        }

        // Método para atualizar a entidade
        public void Atualizar(string sabor, decimal preco, bool comQueijo)
        {
            Sabor = sabor;
            Preco = preco;
            ComQueijo = comQueijo;
        }
    }
}