using lanches.crosscuting.Helper;
using System.Collections.Generic;

namespace lanches.domain.Entities.Base
{
    public abstract class EntityBase
    {
        public string Id { get; private set; }
        public List<Notificacao> Notificacoes { get; private set; } = new List<Notificacao>();
    }
}
