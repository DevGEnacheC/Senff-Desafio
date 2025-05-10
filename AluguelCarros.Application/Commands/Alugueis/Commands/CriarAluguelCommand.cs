using MediatR;

namespace AluguelCarros.Application.Commands.Alugueis.Commands
{
    public class CriarAluguelCommand : IRequest<Guid>
    {
        public Guid CarroId { get; private set; }
        public Guid ClienteId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public decimal ValorAluguel { get; private set; }

        public CriarAluguelCommand(Guid carroId, Guid clienteId,
                                   DateTime dataInicio, DateTime dataFim,
                                   decimal valorAluguel)
        {
            CarroId = carroId;
            ClienteId = clienteId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            ValorAluguel = valorAluguel;
        }

    }
}
