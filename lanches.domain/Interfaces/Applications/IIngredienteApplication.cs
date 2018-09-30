using lanches.crosscuting.Arguments.Ingredientes;
using System.Collections.Generic;

namespace lanches.domain.Interfaces.Applications
{
    public interface IIngredienteApplication
    {
        void Inserir(IngredienteRequest ingredienteRequest);
        void Atualizar(string id, IngredienteRequest ingredienteRequest);
        void Remover(string id);
        IList<IngredienteResponse> ListarTodos();
    }
}
