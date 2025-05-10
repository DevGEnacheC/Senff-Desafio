using AluguelCarros.Application.Commands.Alugueis.Commands;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Alugueis
{
    public class CriarAluguelCommandValidator : AbstractValidator<CriarAluguelCommand>
    {
        public CriarAluguelCommandValidator()
        {
            RuleFor(x => x.CarroId)
            .NotEqual(Guid.Empty)
            .WithMessage("O ID do carro é obrigatório.");

            RuleFor(x => x.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("O ID do cliente é obrigatório.");

            RuleFor(x => x.DataInicio)
                .Cascade(CascadeMode.Continue)
                .NotEmpty().WithMessage("A data de início é obrigatória.")
                .GreaterThanOrEqualTo(DateTime.Today)
                    .WithMessage("A data de início não pode ser anterior a hoje.");

            RuleFor(x => x.DataFim)
                .Cascade(CascadeMode.Continue)
                .NotEmpty().WithMessage("A data de fim é obrigatória.")
                .GreaterThan(x => x.DataInicio)
                    .WithMessage("A data de fim deve ser posterior à data de início.");

            RuleFor(x => x.ValorAluguel)
                .GreaterThan(0)
                    .WithMessage("O valor do aluguel deve ser maior que 0.");
        }
    }
}
