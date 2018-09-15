using lanches.domain.Entities.Base;
using lanches.domain.Enums;
using lanches.domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lanches.domain.Entities
{
    public class Pedido : EntityBase
    {
        public Pedido(IList<Lanche> lanches)
        {
            Data = DateTime.Now;
            Lanches = lanches;
            Total = lanches.Sum(l => l.Valor);

            Validacao();

            foreach (var lanche in Lanches)
                Notificacoes.AdicionarNotificacoes(lanche.Notificacoes);

        }

        private void Validacao()
        {
            ValidarQtdLanches();
            ValidarTotalValor();
        }

        private void ValidarQtdLanches()
        {
            if (Lanches.Count == 0)
                Notificacoes.AdicionarNotificacao("Pedido.ValidarQtdLanches", PedidoResource.SemLanches);
        }

        private void ValidarTotalValor()
        {
            if (Total == 0)
                Notificacoes.AdicionarNotificacao("Pedido.ValidarTotalValor", PedidoResource.ValorZerado);
        }

        public PedidoStatusEnum Status { get; private set; } = PedidoStatusEnum.Pendente;
        public DateTime Data { get; private set; }
        public IList<Lanche> Lanches { get; private set; }
        public decimal Total { get; private set; }
    }
}
