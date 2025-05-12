namespace AluguelCarros.Domain.Entities
{
    public class Carro
    {
        public Guid Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Placa { get; private set; }
        public string Cor { get; private set; }
        public bool Disponivel { get; private set; }
        public double PrecoDiaria { get; private set; }

        private Carro() { }

        public Carro(string marca, string modelo, int ano, string placa, string cor, double precoDiaria)
        {
            Id = Guid.NewGuid();
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            Cor = cor;
            Disponivel = true;
            PrecoDiaria = precoDiaria;
        }

        public void Update(string marca, string modelo, int ano, string placa, string cor, double precoDiaria) 
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            Cor = cor;
            PrecoDiaria= precoDiaria;
        }

        public void Reservar()
        {
            Disponivel = false;
        }

        public void Liberar()
        {
            Disponivel = true;
        }
    }
}
