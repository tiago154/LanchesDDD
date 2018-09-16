using System.ComponentModel.DataAnnotations;

namespace lanches.api.Models
{
    public class IngredienteRequest
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
