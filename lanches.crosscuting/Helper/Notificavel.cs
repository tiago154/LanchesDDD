using lanches.crosscuting.Helper;
using System.Collections.Generic;

namespace lanches.domain.Entities.Base
{
    public static class Notificavel
    {
        public static void AdicionarNotificacao(this List<Notificacao> notificacoes, string campo, string mensagem) => notificacoes.Add(new Notificacao(campo, mensagem));

        public static void AdicionarNotificacoes(this List<Notificacao> notificacoes, params IList<Notificacao>[] listaDeNotificacoes)
        {
            foreach (var item in listaDeNotificacoes)
                notificacoes.AddRange(item);
        }
    }
}
