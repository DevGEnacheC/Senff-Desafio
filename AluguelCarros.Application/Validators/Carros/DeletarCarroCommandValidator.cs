using AluguelCarros.Application.Commands.Carros.Commands;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Carros
{
    public class DeletarCarroCommandValidator : AbstractValidator<DeletarCarroCommand>
    {
        public DeletarCarroCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("O ID do carro é obrigatório.");
        }
    }
}
