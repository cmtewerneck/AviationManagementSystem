using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class ManualVooValidation : AbstractValidator<ManualVoo>
    {
        public ManualVooValidation()
        {
            RuleFor(c => c.ModeloAeronave)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}