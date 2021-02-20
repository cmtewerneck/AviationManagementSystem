using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class VeiculoMultaValidation : AbstractValidator<VeiculoMulta>
    {
        public VeiculoMultaValidation()
        {
            RuleFor(f => f.Data)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.");

            RuleFor(f => f.AutoInfracao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Responsavel)
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Classificacao)
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1,50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Valor)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");
        }
    }
}
