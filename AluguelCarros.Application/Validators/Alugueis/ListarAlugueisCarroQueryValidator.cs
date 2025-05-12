using AluguelCarros.Application.Queries.Alugueis.Queries;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Alugueis
{
    public class ListarAlugueisCarroQueryValidator : AbstractValidator<ListarAlugueisCarroQuery>
    {
        public ListarAlugueisCarroQueryValidator()
        {
            RuleFor(x => x.CarroId)
                .NotEqual(Guid.Empty).WithMessage("O ID do carro é obrigatório.");
        }
    }
}
