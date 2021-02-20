using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class ServicoValidation : AbstractValidator<Servico>
    {
        public ServicoValidation()
        {
            RuleFor(f => f.Codigo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Custo)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");
        }
    }
}