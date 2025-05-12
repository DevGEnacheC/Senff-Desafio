using MediatR;

namespace AluguelCarros.Application.Events.Alugueis.Events
{
    public class AluguelCriadoEvent : INotification
    {
        public Guid Id { get; }
        public Guid CarroId { get; }
        public Guid ClienteId { get; }
        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }

        public AluguelCriadoEvent(Guid id, 
                                  Guid carroId, Guid clienteId, 
                                  DateTime dataInicio, DateTime dataFim)
        {
            Id = id;
            CarroId = carroId;
            ClienteId = clienteId;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }
    }
}
