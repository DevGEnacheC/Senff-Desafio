using MediatR;

namespace AluguelCarros.Application.Commands
{
    public class CriarClienteCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public CriarClienteCommand(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
