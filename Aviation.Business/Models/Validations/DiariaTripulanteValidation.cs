using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class DiariaTripulanteValidation : AbstractValidator<DiariaTripulante>
    {
        public DiariaTripulanteValidation()
        {
            RuleFor(c => c.DataInicio)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Valor)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");

            RuleFor(c => c.Finalidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 500).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.FormaPagamento)
                .Length(1, 30).When(c => c.FormaPagamento != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
