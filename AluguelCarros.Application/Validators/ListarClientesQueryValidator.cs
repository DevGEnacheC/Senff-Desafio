using AluguelCarros.Application.Queries;
using FluentValidation;

namespace AluguelCarros.Application.Validators
{
    public class ListarClientesQueryValidator : AbstractValidator<ListarCarrosQuery>
    {
        public ListarClientesQueryValidator()
        {
        }
    }
}
