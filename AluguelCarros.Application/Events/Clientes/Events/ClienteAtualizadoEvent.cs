using MediatR;

namespace AluguelCarros.Application.Events.Clientes.Events
{
    public class ClienteAtualizadoEvent : INotification
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string CPF { get; }

        public ClienteAtualizadoEvent(Guid id, string nome, string cPF)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
        }
    }
}
