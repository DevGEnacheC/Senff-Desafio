using AluguelCarros.Application.Queries.Alugueis.Queries;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Alugueis
{
    public class AluguelTotalQueryValidator : AbstractValidator<AluguelTotalQuery>
    {
        public AluguelTotalQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("O ID do aluguel é obrigatório.");
        }
    }
}
