using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class LegislacaoValidation : AbstractValidator<Legislacao>
    {
        public LegislacaoValidation()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Numero)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior ou igual a {ComparisonValue}");
        }
    }
}