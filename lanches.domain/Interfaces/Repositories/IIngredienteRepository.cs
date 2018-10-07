using lanches.crosscuting.Models.Mongo;
using System.Collections.Generic;

namespace lanches.domain.Interfaces.Repositories
{
    public interface IIngredienteRepository
    {
        string Inserir(IngredienteCollection ingrediente);
        void Atualizar(IngredienteCollection ingrediente);
        void Remover(string id);
        IList<IngredienteCollection> ListarTodos();
    }
}
