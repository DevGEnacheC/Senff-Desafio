namespace AluguelCarros.Domain.Entities
{
    public class Aluguel
    {
        public Guid Id { get; private set; }
        public Guid CarroId { get; private set; }
        public Guid ClienteId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public DateTime? DataDevolucao { get; private set; }

        private Aluguel() { }

        public Aluguel(Guid carroId, Guid clienteId,
                       DateTime dataInicio, DateTime dataFim)
        {
            Id = Guid.NewGuid();
            CarroId = carroId;
            ClienteId = clienteId;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public void UpdateDataFim(DateTime dataFim)
        {
            DataFim = dataFim;
        }

        public void Devolver(DateTime dataDevolucao)
        {
            DataDevolucao = dataDevolucao;
        }

        public int DiasNormais()
        {
            if(DataDevolucao != null && DataDevolucao < DataFim)
            {
                return ((DataDevolucao ?? DateTime.Today) - DataInicio).Days;
            }

            return (DataFim - DataInicio).Days;
        }

        public int DiasAtraso()
        {
            return ((DataDevolucao ?? DataFim) - DataFim).Days;
        }

    }
}
