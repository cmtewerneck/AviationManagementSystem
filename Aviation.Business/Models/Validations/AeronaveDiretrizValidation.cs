using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class AeronaveDiretrizValidation : AbstractValidator<AeronaveDiretriz>
    {
        public AeronaveDiretrizValidation()
        {
            RuleFor(f => f.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1,100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Referencia)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.DataEfetivacao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.");

            RuleFor(f => f.Descricao)
                .Length(1, 500).When(f => f.Descricao != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.TipoDiretriz)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.");

            RuleFor(f => f.IntervaloHoras)
               .GreaterThanOrEqualTo(0).When(f => f.IntervaloHoras != null).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

            RuleFor(f => f.IntervaloCiclos)
               .GreaterThanOrEqualTo(0).When(f => f.IntervaloCiclos != null).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

            RuleFor(f => f.IntervaloDias)
               .GreaterThanOrEqualTo(0).When(f => f.IntervaloDias != null).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

            RuleFor(f => f.UltimoCumprimentoHoras)
               .GreaterThanOrEqualTo(0).When(f => f.UltimoCumprimentoHoras != null).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

            RuleFor(f => f.UltimoCumprimentoCiclos)
               .GreaterThanOrEqualTo(0).When(f => f.UltimoCumprimentoCiclos != null).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

            RuleFor(f => f.Observacoes)
                .Length(1, 500).When(f => f.Observacoes != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            //RuleFor(f => f.Status)
            //   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.");
        }
    }
}
