using MediatR;

namespace AluguelCarros.Application.Commands.Clientes.Commands
{
    public class CriarClienteCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public CriarClienteCommand(string nome, string cpf, string cnh)
        {
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
        }
    }
}
