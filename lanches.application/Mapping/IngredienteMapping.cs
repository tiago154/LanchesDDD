using lanches.crosscuting.Arguments.Ingredientes;
using lanches.domain.Entities;

namespace lanches.application.Mapping
{
    public class IngredienteMapping
    {
        public static IngredienteResponse Response(Ingrediente ingrediente) => new IngredienteResponse
        {
            Id = ingrediente.Id,
            Nome = ingrediente.Nome,
            Valor = ingrediente.Valor
        };
    }
}
