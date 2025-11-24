using Pamonharia.Domain.Enums;

namespace Pamonharia.Domain.Entities
{
    public class Pamonha
    {
        public int Id { get; private set; }
        public SaborPamonha Sabor { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime DataProducao { get; private set; }

        // Chave Estrangeira e Propriedade de Navegação
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        protected Pamonha() { }

        public Pamonha(SaborPamonha sabor, decimal preco, int categoriaId)
        {
            Sabor = sabor;
            Preco = preco;
            CategoriaId = categoriaId;
            DataProducao = DateTime.UtcNow;
        }

        public void Atualizar(SaborPamonha sabor, decimal preco, int categoriaId)
        {
            Sabor = sabor;
            Preco = preco;
            CategoriaId = categoriaId;
        }
    }
}