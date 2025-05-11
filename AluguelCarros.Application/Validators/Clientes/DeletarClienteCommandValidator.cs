using AluguelCarros.Application.Commands.Clientes.Commands;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Clientes
{
    public class DeletarClienteCommandValidator : AbstractValidator<DeletarClienteCommand>
    {
        public DeletarClienteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("O ID do cliente é obrigatório.");
        }
    }
}
