using lanches.crosscuting.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace lanches.crosscuting.Arguments.Ingredientes
{
    public class IngredienteRequest
    {
        [Required(ErrorMessageResourceType = typeof(IngredienteResource), ErrorMessageResourceName = "CampoObrigatorio")]
        [MinLength(4, ErrorMessageResourceType = typeof(IngredienteResource), ErrorMessageResourceName = "NomeMinimo")]
        public string Nome { get; set; }

        [Range(0.10, 10, ErrorMessageResourceType = typeof(IngredienteResource), ErrorMessageResourceName = "ValorMinimoMaximo")]
        public decimal Valor { get; set; }
    }
}
