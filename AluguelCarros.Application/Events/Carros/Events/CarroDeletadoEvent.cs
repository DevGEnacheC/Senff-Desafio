using MediatR;

namespace AluguelCarros.Application.Events.Carros.Events
{
    public class CarroDeletadoEvent : INotification
    {
        public Guid Id { get; set; }

        public CarroDeletadoEvent(Guid id)
        {
            Id = id;
        }
    }

}
