using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lanches.crosscuting.Models.Mongo
{
    public class IngredienteCollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("valor")]
        public decimal Valor { get; set; }
    }
}
