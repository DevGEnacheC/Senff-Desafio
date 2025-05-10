using MediatR;

namespace AluguelCarros.Application.Events
{
    public class ClienteCriadoEvent : INotification
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string CPF { get; }

        public ClienteCriadoEvent(Guid id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
        }
    }
}
