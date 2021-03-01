using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class SuprimentoValidation : AbstractValidator<Suprimento>
    {
        public SuprimentoValidation()
        {
            RuleFor(c => c.Codigo)
                .Length(1, 30).When(c => c.Codigo != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.PartNumber)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Nomenclatura)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Quantidade)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior ou igual a {ComparisonValue}");

            RuleFor(c => c.Localizacao)
                .Length(1, 30).When(c => c.Localizacao != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.PartNumberAlternativo)
                .Length(1, 30).When(c => c.PartNumberAlternativo != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Aplicacao)
                .Length(1, 20).When(c => c.Aplicacao != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Capitulo)
                .Length(1, 20).When(c => c.Capitulo != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.SerialNumber)
                .Length(1, 30).When(c => c.SerialNumber != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Doc)
                .Length(1, 20).When(c => c.Doc != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
