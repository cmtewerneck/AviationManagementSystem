using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class ItemOrdemServicoValidation : AbstractValidator<ItemOrdemServico>
    {
        public ItemOrdemServicoValidation()
        {
            RuleFor(c => c.Custo)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");
        }
    }
}
