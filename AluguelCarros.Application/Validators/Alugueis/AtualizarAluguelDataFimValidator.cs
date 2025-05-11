using AluguelCarros.Application.Commands.Alugueis.Commands;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Alugueis
{
    public class AtualizarAluguelDataFimValidator : AbstractValidator<AtualizarAluguelDataFimCommand>
    {
        public AtualizarAluguelDataFimValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("O ID do aluguel é obrigatório.");

            RuleFor(x => x.DataFim)
                .NotEmpty().WithMessage("A data fim é obrigatória.")
            .GreaterThan(DateTime.Today)
                    .WithMessage("A data de fim não pode ser anterior a hoje.");
        }
    }
}
