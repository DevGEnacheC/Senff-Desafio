using MediatR;

namespace AluguelCarros.Application.Commands.Alugueis.Commands
{
    public class AtualizarAluguelDataDevolucaoCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DateTime DataDevolucao { get; set; }

        public AtualizarAluguelDataDevolucaoCommand(Guid id, DateTime dataDevolucao)
        {
            Id = id;
            DataDevolucao = dataDevolucao;
        }
    }
}
