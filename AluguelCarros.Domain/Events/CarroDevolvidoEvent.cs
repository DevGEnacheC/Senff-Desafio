namespace AluguelCarros.Infrastructure.Events
{
    public class CarroDevolvidoEvent
    {
        public Guid CarroId { get; }
        public Guid AluguelId { get; }
        public DateTime DataDevolucao { get; }

        public CarroDevolvidoEvent(Guid carroId, Guid aluguelId, DateTime dataDevolucao)
        {
            CarroId = carroId;
            AluguelId = aluguelId;
            DataDevolucao = dataDevolucao;
        }
    }
}
