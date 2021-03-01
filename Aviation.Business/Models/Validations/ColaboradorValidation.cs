using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class ColaboradorValidation : PessoaValidation<Colaborador>
    {
        public ColaboradorValidation() // : base()
        {
            RuleFor(c => c.DataAdmissao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Cargo)
                .Length(1, 30).When(c => c.Cargo != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.CANAC)
                .Length(6).When(c => c.CANAC != "").WithMessage("O campo {PropertyName} precisa ter {ExactLength} caracteres");

            RuleFor(c => c.Salario)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(f => f.RG)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.OrgaoEmissor)
                .Length(1, 20).When(c => c.OrgaoEmissor != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.TituloEleitor)
                .Length(1, 30).When(c => c.TituloEleitor != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.NumeroPis)
               .Length(1, 30).When(c => c.NumeroPis != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.NumeroCtps)
               .Length(1, 30).When(c => c.NumeroCtps != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.NumeroCnh)
               .Length(1, 30).When(c => c.NumeroCnh != "").WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
