using FluentValidation;

namespace AviationManagementApi.Business.Models.Validations
{
    public class AeronaveValidation : AbstractValidator<Aeronave>
    {
        public AeronaveValidation()
        {
            RuleFor(c => c.Matricula)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5).WithMessage("O campo {PropertyName} precisa ter {ExactLength} caracteres");

            RuleFor(c => c.Fabricante)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Categoria)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NumeroSerie)
                .Length(1, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.PesoVazio)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.PesoBasico)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.HorasTotais)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

            RuleFor(c => c.Motor)
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.ModeloMotor)
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NumeroSerieMotor)
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
