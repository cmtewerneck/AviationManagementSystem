using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class EscalaValidation : AbstractValidator<Escala>
    {
        public EscalaValidation()
        {
            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
