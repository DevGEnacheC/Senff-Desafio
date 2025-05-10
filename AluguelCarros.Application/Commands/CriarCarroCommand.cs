using MediatR;

namespace AluguelCarros.Application.Commands
{
    public class CriarCarroCommand : IRequest<Guid>
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }

        public CriarCarroCommand(string marca, string modelo, int ano, string placa)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
        }
    }
}
