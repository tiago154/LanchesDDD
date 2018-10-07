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

                //if validando notificação
                var ingredienteCollection = IngredienteMapping.ConverteParaIngredienteCollection(ingrediente);

                _ingredienteRepository.Atualizar(ingredienteCollection);
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
                //if validando notificação
                var ingredienteCollection = IngredienteMapping.ConverteParaIngredienteCollection(ingrediente);
                _ingredienteRepository.Inserir(ingredienteCollection);
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

                var ingredientesCollection = _ingredienteRepository.ListarTodos();

                foreach (var ingredienteCollection in ingredientesCollection)
                    ingredientesResponse.Add(IngredienteMapping.ConverteParaIngredienteResponse(ingredienteCollection));

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
