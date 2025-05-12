using AluguelCarros.Application.Queries.Carros.Queries;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Carros
{
    public class ListarCarrosQueryValidator : AbstractValidator<ListarCarrosQuery>
    {
        public ListarCarrosQueryValidator()
        {
        }
    }
}
