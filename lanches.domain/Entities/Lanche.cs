using lanches.domain.Entities.Base;
using lanches.domain.ValueObjects;
using System.Collections.Generic;

namespace lanches.domain.Entities
{
    public class Lanche : EntityBase
    {
        public Lanche(string nome, IList<Ingrediente> ingredientes, decimal valor)
        {
            Nome = nome;
            Ingredientes = ingredientes;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public IList<Ingrediente> Ingredientes { get; private set; }
        public decimal Valor { get; private set; }
        public Promocao Promocao { get; private set; }
    }
}
