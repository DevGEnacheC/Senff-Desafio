namespace AluguelCarros.Infrastructure.Entities
{
    public class Carro
    {
        public Guid Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public bool Disponivel { get; private set; }

        private Carro() { }

        public Carro(string marca, string modelo, int ano)
        {
            Id = Guid.NewGuid();
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Disponivel = true;
        }

        public void Reservar()
        {
            if (!Disponivel)
                throw new InvalidOperationException("Carro já está reservado.");
            Disponivel = false;
        }

        public void Liberar()
        {
            Disponivel = true;
        }
    }
}
