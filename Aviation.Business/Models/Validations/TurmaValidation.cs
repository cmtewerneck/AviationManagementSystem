using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class TurmaValidation : AbstractValidator<Turma>
    {
        public TurmaValidation()
        {
            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.DataInicio)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Inscricao)
                .GreaterThanOrEqualTo(0).When(c => c.Inscricao != null).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

            RuleFor(c => c.Mensalidade)
                .GreaterThanOrEqualTo(0).When(c => c.Mensalidade != null).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");
        }
    }
}
