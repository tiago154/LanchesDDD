using lanches.application.Mapping;
using lanches.crosscuting.Arguments.Ingredientes;
using lanches.domain.Entities;
using lanches.domain.Interfaces.Applications;
using lanches.domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace lanches.application
{
    public class IngredienteApplication : IIngredienteApplication
    {
        private readonly IIngredienteRepository _ingredienteRepository;

        public IngredienteApplication(IIngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public void Atualizar(string id, IngredienteRequest ingredienteRequest)
        {
            try
            {
                var ingrediente = new Ingrediente(ingredienteRequest, id);
                _ingredienteRepository.Atualizar(ingrediente);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Inserir(IngredienteRequest ingredienteRequest)
        {
            try
            {
                var ingrediente = new Ingrediente(ingredienteRequest);
                _ingredienteRepository.Inserir(ingrediente);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IList<IngredienteResponse> ListarTodos()
        {
            try
            {
                var ingredientesResponse = new List<IngredienteResponse>();

                var ingredientes = _ingredienteRepository.ListarTodos();

                foreach (var ingrediente in ingredientes)
                    ingredientesResponse.Add(IngredienteMapping.Response(ingrediente));

                return ingredientesResponse;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Remover(string id)
        {
            try
            {
                _ingredienteRepository.Remover(id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
