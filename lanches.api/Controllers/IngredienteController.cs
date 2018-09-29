using lanches.crosscuting.Arguments.Ingredientes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace lanches.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiExplorerSettings(GroupName = "Ingredientes")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Ingrediente
        [HttpPost]
        public void Post([FromBody] IngredienteRequest ingrediente)
        {
        }
    }
}
