using System.Collections.Generic;

namespace lanches.domain.Entities
{
    public class Lanche
    {
        public Lanche(string nome, IList<Ingrediente> ingredientes, decimal valor, Promocao promocao = null)
        {
            Nome = nome;
            Ingredientes = ingredientes;
            Valor = valor;
            Promocao = promocao;

            Validacao();
        }

        private void Validacao()
        {
            ValidarQtdIngredientes();
            ValidarValor();
            ValidarNome();
        }

        private void ValidarNome()
        {
            //if (Nome.Length < 5)
            //    Notificacoes.AdicionarNotificacao("Lanche.ValidarNome", LancheResource.NomeMinimo);
        }

        private void ValidarValor()
        {
            //if (Valor < 1)
            //    Notificacoes.AdicionarNotificacao("Lanche.ValidarValor", LancheResource.ValorMinimo);
        }

        private void ValidarQtdIngredientes()
        {
            //if (Ingredientes.Count == 0)
            //    Notificacoes.AdicionarNotificacao("Lanche.ValidarQtdIngredientes", LancheResource.SemIngredientes);
        }

        public string Nome { get; private set; }
        public IList<Ingrediente> Ingredientes { get; private set; }
        public decimal Valor { get; private set; }
        public Promocao Promocao { get; private set; }
    }
}
