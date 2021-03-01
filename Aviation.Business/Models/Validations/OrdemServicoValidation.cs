using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class OrdemServicoValidation : AbstractValidator<OrdemServico>
    {
        public OrdemServicoValidation()
        {
            RuleFor(f => f.NumeroOrdem)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Tipo)
                .Length(1, 20).When(c => c.Tipo != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Ttsn)
                .Length(1, 20).When(c => c.Ttsn != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.TcsnPousos)
                .Length(1, 20).When(c => c.TcsnPousos != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.DataAbertura)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.");

            RuleFor(f => f.TtsnMotor)
               .Length(1, 20).When(c => c.TtsnMotor != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.TcsnCiclos)
               .Length(1, 20).When(c => c.TcsnCiclos != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.RequisicaoMateriais)
               .Length(1, 300).When(c => c.RequisicaoMateriais != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.RealizadoPor)
               .Length(1, 20).When(c => c.RealizadoPor != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.RealizadoPorAnac)
               .Length(6).When(c => c.RealizadoPorAnac != "").WithMessage("O campo {PropertyName} precisa ter {ExactLength} caracteres");

            RuleFor(f => f.InspecionadoPor)
               .Length(1, 20).When(c => c.InspecionadoPor != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.InspecionadoPorAnac)
               .Length(6).When(c => c.InspecionadoPorAnac != "").WithMessage("O campo {PropertyName} precisa ter {ExactLength} caracteres");
        }
    }
}