using lanches.crosscuting.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace lanches.crosscuting.Arguments.Ingredientes
{
    public class IngredienteRequest
    {
        /// <summary>
        /// Nome
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(IngredienteResource), ErrorMessageResourceName = "CampoObrigatorio")]
        [MinLength(4, ErrorMessageResourceType = typeof(IngredienteResource), ErrorMessageResourceName = "NomeMinimo")]
        public string Nome { get; set; }

        /// <summary>
        /// Valor
        /// Exemplo:
        /// 2.50
        /// </summary>
        [Range(0.10, 10, ErrorMessageResourceType = typeof(IngredienteResource), ErrorMessageResourceName = "ValorMinimoMaximo")]
        public decimal Valor { get; set; }
    }
}
