using MediatR;

namespace AluguelCarros.Application.Commands.Carros.Commands
{
    public class DeletarCarroCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeletarCarroCommand(Guid id)
        {
            Id = id;
        }
    }
}
