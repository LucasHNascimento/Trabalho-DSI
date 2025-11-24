using System.ComponentModel.DataAnnotations;
using Pamonharia.Application.Validations; // Certifique-se que o namespace existe

namespace Pamonharia.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [SemPalavrasProibidas] // Validação customizada criada anteriormente
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres")]
        public string Descricao { get; set; }
    }
}