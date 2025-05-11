using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public decimal ValorAluguel { get; }

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
