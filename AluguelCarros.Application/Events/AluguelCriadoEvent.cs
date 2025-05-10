using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AluguelCarros.Application.Events
{
    public class AluguelCriadoEvent : INotification
    {
        public Guid Id { get; private set; }
        public Guid CarroId { get; private set; }
        public Guid ClienteId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public decimal ValorAluguel { get; private set; }

        public AluguelCriadoEvent(Guid id, 
                                  Guid carroId, Guid clienteId, 
                                  DateTime dataInicio, DateTime dataFim,
                                  decimal valorAluguel)
        {
            Id = id;
            CarroId = carroId;
            ClienteId = clienteId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            ValorAluguel = valorAluguel;
        }
    }
}
