using MediatR;

namespace AluguelCarros.Application.Commands.Carros.Commands
{
    public class AtualizarCarroCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public bool Disponivel { get; set; }
        public double PrecoDiaria { get; set; }


        public AtualizarCarroCommand(Guid id, string marca, string modelo, int ano, string placa, 
                                    string cor, bool disponivel, double precoDiaria)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            Cor = cor;
            Disponivel = disponivel;
            PrecoDiaria = precoDiaria;
        }

    }
}
