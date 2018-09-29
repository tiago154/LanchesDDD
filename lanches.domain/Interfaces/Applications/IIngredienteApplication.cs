using lanches.crosscuting.Arguments.Ingredientes;
using System.Collections.Generic;

namespace lanches.domain.Interfaces.Applications
{
    public interface IIngredienteApplication
    {
        void InserirIngrediente(IngredienteRequest ingredienteRequest);
        IList<IngredienteResponse> RetornaIngredientes();
    }
}
