using MediatR;

namespace AluguelCarros.Application.Events.Clientes.Events
{
    public class ClienteAtualizadoEvent : INotification
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string CPF { get; }
        public string CNH { get; }

        public ClienteAtualizadoEvent(Guid id, string nome, string cpf, string cnh)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
        }
    }
}
