using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class DiarioBordoValidation : AbstractValidator<DiarioBordo>
    {
        public DiarioBordoValidation()
        {
            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Base)
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.De)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(4).WithMessage("O campo {PropertyName} precisa ter {ExactLength} caracteres");

            RuleFor(c => c.Para)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(4).WithMessage("O campo {PropertyName} precisa ter {ExactLength} caracteres");

            RuleFor(c => c.HoraAcionamento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.HoraCorte)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.TotalDecimal)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");

            RuleFor(c => c.TotalDecPouso)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");
            
            RuleFor(c => c.TotalAcionamentoCorte)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior ou igual a {ComparisonValue}");

            RuleFor(c => c.Pousos)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior ou igual a {ComparisonValue}");

            RuleFor(c => c.Pob)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");

            RuleFor(c => c.CombustivelDecolagem)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");

            RuleFor(c => c.PreVooResponsavel)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.PosVooResponsavel)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Observacoes)
                .Length(1, 300).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Discrepancias)
                .Length(1, 300).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.AcoesCorretivas)
                .Length(1, 300).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
