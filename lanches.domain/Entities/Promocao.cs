using lanches.domain.Entities.Base;
using lanches.domain.Enums;
using lanches.domain.ValueObjects;
using System.Collections.Generic;

namespace lanches.domain.Entities
{
    public class Promocao : EntityBase
    {
        public Promocao(string nome, PromocaoTipoEnum tipo, IList<Ingrediente> deveConter, IList<Ingrediente> naoDeveConter)
        {
            Nome = nome;
            Tipo = tipo;
            DeveConter = deveConter;
            NaoDeveConter = naoDeveConter;
        }

        public Promocao(string nome, PromocaoTipoEnum tipo, Ingrediente aCada, int pagaApenas)
        {
            Nome = nome;
            Tipo = tipo;
            ACada = aCada;
            PagaApenas = pagaApenas;
        }

        public string Nome { get; private set; }
        public PromocaoTipoEnum Tipo { get; private set; }
        public IList<Ingrediente> DeveConter { get; private set; }
        public IList<Ingrediente> NaoDeveConter { get; private set; }
        public Ingrediente ACada { get; private set; }
        public int PagaApenas { get; private set; }
    }
}
