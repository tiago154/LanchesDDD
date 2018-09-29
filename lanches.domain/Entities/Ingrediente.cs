namespace lanches.domain.Entities
{

    public class Ingrediente
    {
        public Ingrediente(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
    }
}
