namespace AluguelCarros.Infrastructure.Entities
{
    public class Carro
    {
        // dotnet ef migrations add InitialCreate --project AluguelCarros.Infrastructure --startup-project AluguelCarros.API
        // dotnet ef database update --project AluguelCarros.Infrastructure --startup-project AluguelCarros.API
       
        public Guid Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Placa { get; private set; }
        public bool Disponivel { get; private set; }

        private Carro() { }

        public Carro(string marca, string modelo, int ano, string placa)
        {
            Id = Guid.NewGuid();
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Disponivel = true;
            Placa = placa;
        }

        public void Update(string marca, string modelo, int ano, string placa) 
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
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
