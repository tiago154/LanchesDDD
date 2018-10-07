using lanches.crosscuting.Arguments.Ingredientes;
using lanches.crosscuting.Models.Mongo;
using lanches.domain.Entities;
using MongoDB.Bson;

namespace lanches.application.Mapping
{
    public class IngredienteMapping
    {
        public static IngredienteResponse ConverteParaIngredienteResponse(IngredienteCollection ingredienteCollection) => new IngredienteResponse
        {
            Id = ingredienteCollection.Id.ToString(),
            Nome = ingredienteCollection.Nome,
            Valor = ingredienteCollection.Valor
        };

        public static IngredienteCollection ConverteParaIngredienteCollection(Ingrediente ingrediente) => new IngredienteCollection
        {
            Id = !string.IsNullOrEmpty(ingrediente.Id) ? ObjectId.Parse(ingrediente.Id) : ObjectId.Empty,
            Nome = ingrediente.Nome,
            Valor = ingrediente.Valor
        };
    }
}
