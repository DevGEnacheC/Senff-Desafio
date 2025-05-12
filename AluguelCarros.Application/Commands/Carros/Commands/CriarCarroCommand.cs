using MediatR;

namespace AluguelCarros.Application.Commands.Carros.Commands
{
    public class CriarCarroCommand : IRequest<Guid>
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public double PrecoDiaria { get; set; }

        public CriarCarroCommand(string marca, string modelo, int ano, string placa, string cor, double precoDiaria)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            Cor = cor;
            PrecoDiaria = precoDiaria;
        }
    }
}
