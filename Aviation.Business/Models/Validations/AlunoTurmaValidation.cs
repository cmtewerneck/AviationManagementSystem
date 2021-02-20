using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class AlunoTurmaValidation : AbstractValidator<AlunoTurma>
    {
        public AlunoTurmaValidation()
        {
            RuleFor(f => f.DataInscricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
