using lanches.crosscuting.Models.Mongo;
using lanches.domain.Entities;
using lanches.domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;

namespace lanches.infra
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly IMongoCollection<IngredienteCollection> _ingredienteCollection;

        public IngredienteRepository(IMongoDatabase database)
        {
            _ingredienteCollection = database.GetCollection<IngredienteCollection>("ingredientes");
        }

        public void Atualizar(IngredienteCollection ingrediente)
        {
            var tryCount = 5;
            var success = false;

            do
            {
                try
                {
                    var filter = Builders<IngredienteCollection>.Filter.Eq(t => t.Id, ingrediente.Id);
                    var update = Builders<IngredienteCollection>.Update
                        .Set(t => t.Nome, ingrediente.Nome)
                        .Set(t => t.Valor, ingrediente.Valor);

                    _ingredienteCollection.UpdateOne(filter, update);

                    success = true;
                }
                catch (System.Exception)
                {
                    tryCount--;
                    Thread.Sleep(1000);
                    if (tryCount == 0)
                        throw;
                }
            } while (!success && tryCount > 0);
        }

        public string Inserir(IngredienteCollection ingrediente)
        {
            var tryCount = 5;
            var success = false;
            string hashMongo = string.Empty;

            do
            {
                try
                {
                    _ingredienteCollection.InsertOne(ingrediente);
                    hashMongo = ingrediente.Id.ToString();
                    success = true;
                }
                catch (System.Exception)
                {
                    tryCount--;
                    Thread.Sleep(1000);
                    if (tryCount == 0)
                        throw;
                }
            } while (!success && tryCount > 0);

            return hashMongo;
        }

        public IList<IngredienteCollection> ListarTodos()
        {
            var tryCount = 5;
            var success = false;
            List<IngredienteCollection> ingredientes = new List<IngredienteCollection>();

            do
            {
                try
                {
                    var filter = Builders<IngredienteCollection>.Filter.Empty;
                    ingredientes = _ingredienteCollection.Find(filter).ToList();

                    success = true;
                }
                catch (System.Exception)
                {
                    tryCount--;
                    Thread.Sleep(1000);
                    if (tryCount == 0)
                        throw;
                }
            } while (!success && tryCount > 0);

            return ingredientes;
        }

        public void Remover(string id)
        {
            var tryCount = 5;
            var success = false;

            do
            {
                try
                {
                    var filter = Builders<IngredienteCollection>.Filter.Eq(t => t.Id, ObjectId.Parse(id));
                    _ingredienteCollection.DeleteOne(filter);

                    success = true;
                }
                catch (System.Exception)
                {
                    tryCount--;
                    Thread.Sleep(1000);
                    if (tryCount == 0)
                        throw;
                }
            } while (!success && tryCount > 0);
        }
    }
}
