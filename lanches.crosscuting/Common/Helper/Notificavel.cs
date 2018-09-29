using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace lanches.crosscuting.Common.Helper
{
    public static class Notificavel
    {
        public static void AdicionarNotificacao(this List<Notificacao> notificacoes, string campo, string mensagem) => notificacoes.Add(new Notificacao(campo, mensagem));

        public static void AdicionarNotificacoes(this List<Notificacao> notificacoes, params IList<Notificacao>[] listaDeNotificacoes)
        {
            foreach (var item in listaDeNotificacoes)
                notificacoes.AddRange(item);
        }

        public static void AdicionarMultiplasNotificacoes(this List<Notificacao> notifications, IEnumerable<IList<Notificacao>> multiplasNotificacoes)
        {
            notifications.AddRange(multiplasNotificacoes.ToList().SelectMany(x => x).GroupBy(x => x.Campo).Select(s => s.First()).ToList());
        }

        public static object ListarError(this List<Notificacao> notificacoes)
        {
            dynamic expando = new ExpandoObject();
            AdicionarPropriedade(expando, notificacoes);
            return expando;
        }


        private static void AdicionarPropriedade(ExpandoObject expando, List<Notificacao> notificacoes)
        {
            var campos = notificacoes.Select(s => s.Campo);
            foreach (var nomePropriedade in campos)
            {
                var expandoDict = expando as IDictionary<string, object>;
                if (expandoDict.ContainsKey(nomePropriedade))
                    expandoDict[nomePropriedade] = notificacoes.Where(w => w.Campo == nomePropriedade).Select(s => s.Mensagem).OrderBy(o => o);
                else
                    expandoDict.Add(nomePropriedade, notificacoes.Where(w => w.Campo == nomePropriedade).Select(s => s.Mensagem).OrderBy(o => o));
            }
        }
    }
}
