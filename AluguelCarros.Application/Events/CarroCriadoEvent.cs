using MediatR;

namespace AluguelCarros.Application.Events
{
    public class CarroCriadoEvent : INotification
    {
        public Guid Id { get; }
        public string Marca { get; }
        public string Modelo { get; }
        public int Ano { get; }

        public string Placa { get; }

        public CarroCriadoEvent(Guid id, string marca, string modelo, int ano, string placa)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
        }
    }
}
