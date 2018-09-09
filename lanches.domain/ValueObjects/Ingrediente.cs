namespace lanches.domain.ValueObjects
{
    public class Ingrediente
    {
        public Ingrediente(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
    }
}
