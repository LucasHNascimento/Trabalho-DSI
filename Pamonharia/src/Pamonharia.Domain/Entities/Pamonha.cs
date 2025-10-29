using Pamonharia.Domain.Enums;

namespace Pamonharia.Domain.Entities
{
    public class Pamonha
    {
        public int Id { get; private set; }
        public SaborPamonha Sabor { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime DataProducao { get; private set; }

        // Construtor para o EF Core
        private Pamonha() { } 

        // Construtor para criar uma nova pamonha
        public Pamonha(SaborPamonha sabor, decimal preco)
        {
            Sabor = sabor;
            Preco = preco;
            DataProducao = DateTime.UtcNow;
            // Validações de domínio (DDD) podem ir aqui
        }

        // Método para atualizar a entidade
        public void Atualizar(SaborPamonha sabor, decimal preco)
        {
            Sabor = sabor;
            Preco = preco;
        }
    }
}