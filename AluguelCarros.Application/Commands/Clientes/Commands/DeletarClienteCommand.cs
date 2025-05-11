using MediatR;

namespace AluguelCarros.Application.Commands.Clientes.Commands
{
    public class DeletarClienteCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeletarClienteCommand(Guid id)
        {
            Id = id;
        }
    }
}
