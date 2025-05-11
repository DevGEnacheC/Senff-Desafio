using MediatR;

namespace AluguelCarros.Application.Commands.Clientes.Commands
{
    public class AtualizarClienteCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        
        public AtualizarClienteCommand(Guid id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
        }
    }
}
