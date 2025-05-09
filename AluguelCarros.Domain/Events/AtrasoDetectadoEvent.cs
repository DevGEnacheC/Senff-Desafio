namespace AluguelCarros.Infrastructure.Events
{
    public class AtrasoDetectadoEvent
    {
        public Guid AluguelId { get; }
        public decimal TaxaAtraso { get; }

        public AtrasoDetectadoEvent(Guid aluguelId, decimal taxaAtraso)
        {
            AluguelId = aluguelId;
            TaxaAtraso = taxaAtraso;
        }
    }
}
