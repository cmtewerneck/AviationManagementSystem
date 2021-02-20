using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class ContasPagarValidation : ContasValidation<ContasPagar>
    {
        public ContasPagarValidation()
        {
            RuleFor(c => c.ValorPagar)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");

            RuleFor(c => c.ValorPago)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
