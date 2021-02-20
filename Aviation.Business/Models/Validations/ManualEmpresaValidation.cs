using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class ManualEmpresaValidation : AbstractValidator<ManualEmpresa>
    {
        public ManualEmpresaValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Sigla)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.RevisaoAtual)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior ou igual a {ComparisonValue}");

            RuleFor(c => c.DataRevisao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.RevisaoAnalise)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");
        }
    }
}