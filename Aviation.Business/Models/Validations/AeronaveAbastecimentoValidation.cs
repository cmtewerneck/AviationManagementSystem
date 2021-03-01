using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class AeronaveAbastecimentoValidation : AbstractValidator<AeronaveAbastecimento>
    {
        public AeronaveAbastecimentoValidation()
        {
            RuleFor(f => f.Data)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.");

            RuleFor(f => f.Litros)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior do que {ComparisonValue}");

            RuleFor(f => f.Local)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1,20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Cupom)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.NotaFiscal)
               .Length(1, 20).When(c => c.NotaFiscal != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Fornecedora)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
               .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Responsavel)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
              .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Valor)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(f => f.Observacoes)
               .Length(1, 100).When(c => c.Observacoes != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
