using System;
using System.ComponentModel.DataAnnotations;

namespace Pamonharia.Application.ViewModels
{
    // DTO (Data Transfer Object) / ViewModel usado pela camada de Apresentação
    public class PamonhaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O sabor é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O sabor deve ter entre 3 e 100 caracteres")]
        public string Sabor { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [DataType(DataType.Currency)]
        [Range(0.01, 1000.00, ErrorMessage = "O preço deve ser entre R$ 0,01 e R$ 1.000,00")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Vem com queijo?")]
        public bool ComQueijo { get; set; }

        [Display(Name = "Data de Produção")]
        [DataType(DataType.Date)]
        public DateTime DataProducao { get; set; }
    }
}