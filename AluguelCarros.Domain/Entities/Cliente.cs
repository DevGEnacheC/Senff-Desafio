namespace AluguelCarros.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }

        private Cliente() { }

        public Cliente(string nome, string cpf)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
        }

        public void Update(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
