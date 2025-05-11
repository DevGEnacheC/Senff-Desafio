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
        public bool Disponivel { get; }

        public CarroAtualizadoEvent(Guid id, string marca, string modelo, int ano, string placa, bool disponivel)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            Disponivel = disponivel;
        }

    }
}
