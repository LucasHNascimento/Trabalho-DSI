using System.ComponentModel.DataAnnotations;

namespace Pamonharia.Application.Validations
{
    public class DataNaoFuturaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime data)
            {
                // Verifica se a data é maior que agora (futuro)
                if (data > DateTime.UtcNow)
                {
                    return new ValidationResult("A data não pode estar no futuro.");
                }
            }
            return ValidationResult.Success;
        }
    }
}