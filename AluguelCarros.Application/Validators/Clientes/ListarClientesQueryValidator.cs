using AluguelCarros.Application.Queries.Carros.Queries;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Clientes
{
    public class ListarClientesQueryValidator : AbstractValidator<ListarCarrosQuery>
    {
        public ListarClientesQueryValidator()
        {
        }
    }
}
