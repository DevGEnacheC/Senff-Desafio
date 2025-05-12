using MediatR;

namespace AluguelCarros.Application.Events.Carros.Events
{
    public class CarroAtualizadoEvent : INotification
    {
        
        public Guid Id { get; set; }
        public string Marca { get; }
        public string Modelo { get; }
        public int Ano { get; set; }
        public string Placa { get; }
        public string Cor { get; }
        public double PrecoDiaria { get; }

        public CarroAtualizadoEvent(Guid id, string marca, string modelo, int ano, 
                                    string placa, string cor, double precoDiaria)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            Cor = cor;
            PrecoDiaria = precoDiaria;
        }

    }
}
