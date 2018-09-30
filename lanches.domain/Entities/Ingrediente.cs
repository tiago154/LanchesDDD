using lanches.crosscuting.Arguments.Ingredientes;

namespace lanches.domain.Entities
{

    public class Ingrediente
    {
        public Ingrediente(IngredienteRequest ingredienteRequest)
        {
            Nome = ingredienteRequest.Nome;
            Valor = ingredienteRequest.Valor;
        }

        public Ingrediente(IngredienteRequest ingredienteRequest, string id)
        {
            Id = id;
            Nome = ingredienteRequest.Nome;
            Valor = ingredienteRequest.Valor;
        }

        public void SetId(string id) => Id = id;

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
    }
}
