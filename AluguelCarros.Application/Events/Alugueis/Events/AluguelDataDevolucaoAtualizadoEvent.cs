using MediatR;

namespace AluguelCarros.Application.Events.Alugueis.Events
{
    public class AluguelDataDevolucaoAtualizadoEvent : INotification
    {
        public Guid Id { get; }
        public DateTime? DataDevolucao { get; }

        public AluguelDataDevolucaoAtualizadoEvent(Guid id, DateTime? dataDevolucao)
        {
            Id = id;
            DataDevolucao = dataDevolucao;
        }
    }
}
