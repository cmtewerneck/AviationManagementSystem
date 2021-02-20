using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class TurmaValidation : AbstractValidator<Turma>
    {
        public TurmaValidation()
        {
            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.DataInicio)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
