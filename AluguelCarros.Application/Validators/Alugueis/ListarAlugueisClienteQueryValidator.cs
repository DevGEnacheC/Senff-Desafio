using AluguelCarros.Application.Queries.Alugueis.Queries;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Alugueis
{
    public class ListarAlugueisClienteQueryValidator : AbstractValidator<ListarAlugueisClienteQuery>
    {
        public ListarAlugueisClienteQueryValidator()
        {
            RuleFor(x => x.ClienteId)
                .NotEqual(Guid.Empty).WithMessage("O ID do cliente é obrigatório.");
        }
    }
}
