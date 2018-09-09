using lanches.domain.Entities.Base;
using lanches.domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lanches.domain.Entities
{
    public class Pedido : EntityBase
    {
        
        public Pedido(IList<Lanche> lanches)
        {
            Status = PedidoStatusEnum.Pendente;
            Data = DateTime.Now;
            Lanches = lanches;
            Total = lanches.Sum(l => l.Valor);
        }

        public PedidoStatusEnum Status { get; private set; }
        public DateTime Data { get; private set; }
        public IList<Lanche> Lanches { get; private set; }
        public decimal Total { get; private set; }
    }
}
