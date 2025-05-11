using MediatR;

namespace AluguelCarros.Application.Events.Clientes.Events
{
    public class ClienteDeletadoEvent : INotification
    {
        public Guid Id { get; set; }

        public ClienteDeletadoEvent(Guid id)
        {
            Id = id;
        }
    }

}
