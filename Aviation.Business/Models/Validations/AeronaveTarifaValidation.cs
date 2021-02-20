using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class AeronaveTarifaValidation : AbstractValidator<AeronaveTarifa>
    {
        public AeronaveTarifaValidation()
        {
            RuleFor(c => c.Data)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Vencimento)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Valor)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");

            RuleFor(c => c.Numeracao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
