using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class AlunoValidation : PessoaValidation<Aluno>
    {
        public AlunoValidation() //: base()
        {
            RuleFor(f => f.RG)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); ;

            RuleFor(f => f.CANAC)
                .Length(6).When(c => c.CANAC != "").WithMessage("O campo {PropertyName} precisa ter {ExactLength} caracteres");

            RuleFor(f => f.TotalVoado)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

            RuleFor(f => f.DataNascimento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
