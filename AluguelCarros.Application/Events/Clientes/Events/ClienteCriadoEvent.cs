using MediatR;

namespace AluguelCarros.Application.Events.Clientes.Events
{
    public class ClienteCriadoEvent : INotification
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string CPF { get; }
        public string CNH { get; }

        public ClienteCriadoEvent(Guid id, string nome, string cpf, string cnh)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
        }
    }
}
