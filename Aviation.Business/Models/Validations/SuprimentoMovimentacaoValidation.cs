using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class SuprimentoMovimentacaoValidation : AbstractValidator<SuprimentoMovimentacao>
    {
        public SuprimentoMovimentacaoValidation()
        {
            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");
        }
    }
}
