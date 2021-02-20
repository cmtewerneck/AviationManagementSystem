using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class OficioRecebidoValidation : AbstractValidator<OficioRecebido>
    {
        public OficioRecebidoValidation()
        {
            RuleFor(f => f.Data)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.");

            RuleFor(f => f.Numeracao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); ;

            RuleFor(c => c.Assunto)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Remetente)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); ;
        }
    }
}
