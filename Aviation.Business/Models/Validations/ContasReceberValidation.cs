using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class ContasReceberValidation : ContasValidation<ContasReceber>
    {
        public ContasReceberValidation()
        {
            RuleFor(c => c.ValorReceber)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");

            RuleFor(c => c.ValorRecebido)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
