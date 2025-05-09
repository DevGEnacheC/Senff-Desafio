namespace AluguelCarros.Infrastructure.Events
{
    public class CarroReservadoEvent
    {
        public Guid CarroId { get; }
        public Guid AluguelId { get; }

        public CarroReservadoEvent(Guid carroId, Guid aluguelId)
        {
            CarroId = carroId;
            AluguelId = aluguelId;
        }
    }
}
