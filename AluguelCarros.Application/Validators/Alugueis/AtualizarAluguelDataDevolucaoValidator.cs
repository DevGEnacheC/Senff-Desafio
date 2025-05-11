using AluguelCarros.Application.Commands.Alugueis.Commands;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Alugueis
{
    public class AtualizarAluguelDataDevolucaoValidator : AbstractValidator<AtualizarAluguelDataDevolucaoCommand>
    {
        public AtualizarAluguelDataDevolucaoValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("O ID do aluguel é obrigatório.");

            RuleFor(x => x.DataDevolucao)
                .Cascade(CascadeMode.Continue)
                .NotEmpty().WithMessage("A data de devolução é obrigatória.")
                .GreaterThanOrEqualTo(DateTime.Today)
                    .WithMessage("A data de devolução não pode ser anterior a hoje.");
        }
    }
}
