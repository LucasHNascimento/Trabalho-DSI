using Pamonharia.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pamonharia.Application.ViewModels
{
    public class PamonhaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O sabor é obrigatório")]
        public SaborPamonha Sabor { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, 100.00, ErrorMessage = "O preço deve ser entre R$0,01 e R$100,00")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        public DateTime DataProducao { get; set; }
    }
}