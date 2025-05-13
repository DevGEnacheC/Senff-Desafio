namespace AluguelCarros.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string CNH { get; private set; }

        private Cliente() { }

        public Cliente(string nome, string cpf, string cnh)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
        }

        public void Update(string nome, string cpf, string cnh)
        {
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
        }
    }
}
