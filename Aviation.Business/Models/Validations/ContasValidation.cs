using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class ContasValidation<TEntity> : AbstractValidator<TEntity> where TEntity : Contas
    {
        public ContasValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.CodigoBarras)
                .Length(1, 50).When(c => c.CodigoBarras != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.FormaPagamento)
                .Length(1, 30).When(c => c.FormaPagamento != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
