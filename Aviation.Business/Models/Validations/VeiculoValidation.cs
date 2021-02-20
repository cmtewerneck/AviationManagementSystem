using FluentValidation;
using System;

namespace AviationManagementApi.Business.Models.Validations
{
    public class VeiculoValidation : AbstractValidator<Veiculo>
    {
        private int AnoAtual = DateTime.Now.Year;

        public VeiculoValidation()
        {
            RuleFor(f => f.Placa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(7, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.UfPlaca)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(2).WithMessage("O campo {PropertyName} precisa ter {ExactLength} caracteres.");

            RuleFor(f => f.Ano)
                .InclusiveBetween(1950,AnoAtual).WithMessage("Ano inválido.");

            RuleFor(f => f.KmAtual)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

            RuleFor(f => f.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1,30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Renavam)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
