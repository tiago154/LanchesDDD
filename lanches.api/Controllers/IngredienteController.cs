using lanches.crosscuting.Arguments.Ingredientes;
using lanches.domain.Interfaces.Applications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace lanches.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteApplication _ingredienteApplication;

        public IngredienteController(IIngredienteApplication ingredienteApplication)
        {
            _ingredienteApplication = ingredienteApplication;
        }

        /// <summary>
        /// Retorna todos os ingredientes
        /// </summary>
        /// <response code="200">Sucesso</response>
        /// <response code="204">Sem conteúdo</response>
        /// <response code="500">Erro interno</response>
        [HttpGet]
        [ApiExplorerSettings(GroupName = "Ingredientes")]
        [ProducesResponseType(200, Type = typeof(IList<IngredienteResponse>))]
        public IActionResult Get()
        {
            try
            {
                var ingredientes = _ingredienteApplication.ListarTodos();

                if (ingredientes.Count > 0)
                    return Ok(ingredientes);
                else
                    return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Adiciona um novo ingrediente
        /// </summary>
        /// <param name="ingrediente">Ingrediente</param>
        /// <response code="201">Criado</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] IngredienteRequest ingrediente)
        {
            try
            {
                _ingredienteApplication.Inserir(ingrediente);

                return StatusCode(201);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }  
        }

        /// <summary>
        /// Atualiza um ingrediente
        /// </summary>
        /// <param name="ingrediente">Ingrediente</param>
        /// <param name="id">Identificador do ingrediente</param>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="500">Erro interno</response>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] IngredienteRequest ingrediente)
        {
            try
            {
                _ingredienteApplication.Atualizar(id, ingrediente);

                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remove um ingrediente
        /// </summary>
        /// <param name="id">Identificador do ingrediente</param>
        /// <response code="200">Sucesso</response>
        /// <response code="500">Erro interno</response>
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                _ingredienteApplication.Remover(id);

                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            } 
        }
    }
}
