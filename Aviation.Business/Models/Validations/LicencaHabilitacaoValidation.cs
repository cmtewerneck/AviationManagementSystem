using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class LicencaHabilitacaoValidation : AbstractValidator<LicencaHabilitacao>
    {
        public LicencaHabilitacaoValidation()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Validade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
