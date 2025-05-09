using AluguelCarros.Application.Commands;
using FluentValidation;

namespace AluguelCarros.Application.Validators
{
    public class CriarCarroCommandValidator : AbstractValidator<CriarCarroCommand>
    {
        public CriarCarroCommandValidator()
        {
            RuleFor(x => x.Marca)
                .NotEmpty().WithMessage("A marca é obrigatória.")
                .MaximumLength(50).WithMessage("A marca não pode exceder 50 caracteres.");

            RuleFor(x => x.Modelo)
                .NotEmpty().WithMessage("O modelo é obrigatório.")
                .MaximumLength(50).WithMessage("O modelo não pode exceder 50 caracteres.");

            RuleFor(x => x.Ano)
                .GreaterThan(1900).WithMessage("O ano deve ser maior que 1900.")
                .LessThanOrEqualTo(DateTime.Now.Year + 1).WithMessage("O ano não pode ser maior que o próximo ano.");
        }
    }
}
