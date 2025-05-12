using AluguelCarros.Application.Queries.Alugueis.Queries;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Alugueis
{
    public class ListarAlugueisQueryValidator : AbstractValidator<ListarAlugueisQuery>
    {
        public ListarAlugueisQueryValidator()
        {
        }
    }
}
