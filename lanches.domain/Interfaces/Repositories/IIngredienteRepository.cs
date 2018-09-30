using lanches.domain.Entities;
using System.Collections.Generic;

namespace lanches.domain.Interfaces.Repositories
{
    public interface IIngredienteRepository
    {
        void Inserir(Ingrediente ingrediente);
        void Atualizar(Ingrediente ingrediente);
        void Remover(string id);
        IList<Ingrediente> ListarTodos();
    }
}
