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
        public decimal ValorAluguel { get; private set; }
        public decimal TaxaAtraso { get; private set; }

        private Aluguel() { }

        public Aluguel(Guid carroId, Guid clienteId, 
                       DateTime dataInicio, DateTime dataFim, 
                       decimal valorAluguel)
        {
            Id = Guid.NewGuid();
            CarroId = carroId;
            ClienteId = clienteId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            ValorAluguel = valorAluguel;
            TaxaAtraso = 0;
        }

        public void UpdateDataFim(DateTime dataFim)
        {
            DataFim = dataFim;
        }

        public void Devolver(DateTime dataDevolucao)
        {
            DataDevolucao = dataDevolucao;
            if (dataDevolucao > DataFim)
            {
                TaxaAtraso = CalcularTaxaAtraso(dataDevolucao);
            }
        }

        private decimal CalcularTaxaAtraso(DateTime dataDevolucao)
        {
            var diasAtraso = (dataDevolucao - DataFim).Days;

            // 50% a mais do aluguel por dia atrasado!
            // Ou seja, 2 dias de atraso equivalem ao preço original do aluguel.
            return diasAtraso * 50;
        }

        public decimal ValorTotal()
        {   
            if(TaxaAtraso > 0) return ValorAluguel + (ValorAluguel * (TaxaAtraso / 100));
            return ValorAluguel;
        }
    }
}
