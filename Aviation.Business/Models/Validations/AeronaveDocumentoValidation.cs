using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class AeronaveDocumentoValidation : AbstractValidator<AeronaveDocumento>
    {
        public AeronaveDocumentoValidation()
        {
            RuleFor(f => f.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1,50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.DataValidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.");
        }
    }
}
