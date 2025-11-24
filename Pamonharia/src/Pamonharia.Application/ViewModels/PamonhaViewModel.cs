using Pamonharia.Domain.Enums;
using Pamonharia.Application.Validations; 
using System.ComponentModel.DataAnnotations;

namespace Pamonharia.Application.ViewModels
{
    public class PamonhaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O sabor é obrigatório")]
        public SaborPamonha Sabor { get; set; }

        [Required]
        [Range(0.01, 100.00)]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        // Se você ainda não criou o arquivo DataNaoFuturaAttribute.cs, remova esta linha abaixo
        [DataNaoFutura] 
        public DateTime DataProducao { get; set; }

        [Required(ErrorMessage = "A Categoria é obrigatória")]
        public int CategoriaId { get; set; }

        public string? CategoriaNome { get; set; }
    }
}