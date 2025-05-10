using MediatR;

namespace AluguelCarros.Application.Commands.Clientes.Commands
{
    public class CriarClienteCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public CriarClienteCommand(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
