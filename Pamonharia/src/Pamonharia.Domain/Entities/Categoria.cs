namespace Pamonharia.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        
        // Relacionamento 1:N (Uma categoria tem muitas pamonhas)
        public ICollection<Pamonha> Pamonhas { get; private set; } = new List<Pamonha>();

        public Categoria(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        // Construtor vazio para o EF Core
        protected Categoria() { }

        public void Atualizar(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}