using System.ComponentModel.DataAnnotations;

namespace Pamonharia.Application.Validations
{
    public class SemPalavrasProibidasAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string texto)
            {
                if (texto.ToLower().Contains("teste") || texto.ToLower().Contains("inválido"))
                {
                    return new ValidationResult("O texto contém palavras proibidas (teste, inválido).");
                }
            }
            return ValidationResult.Success;
        }
    }
}