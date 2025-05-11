using MediatR;

namespace AluguelCarros.Application.Events.Alugueis.Events
{
    public class AluguelDataFimAtualizadoEvent : INotification
    {
        public Guid Id { get; }
        public DateTime DataFim { get; }

        public AluguelDataFimAtualizadoEvent(Guid id, DateTime dataFim)
        {
            Id = id;
            DataFim = dataFim;
        }

    }
}
