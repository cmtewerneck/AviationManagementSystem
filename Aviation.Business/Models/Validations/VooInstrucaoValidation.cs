using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class VooInstrucaoValidation : AbstractValidator<VooInstrucao>
    {
        public VooInstrucaoValidation()
        {
            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.TempoVoo)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido e maior que {ComparisonValue}");

            RuleFor(c => c.Observacoes)
                .Length(1, 200).When(c => c.Observacoes != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
