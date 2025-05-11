using MediatR;

namespace AluguelCarros.Application.Commands.Alugueis.Commands
{
    public class AtualizarAluguelDataFimCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DateTime DataFim { get; set; }

        public AtualizarAluguelDataFimCommand(Guid id, DateTime dataFim)
        {
            Id = id;
            DataFim = dataFim;
        }
    }
}
