using System.Collections.Generic;

namespace lanches.domain.Entities.Base
{
    public class Notificavel
    {
        public List<Notificacao> Notificacoes { get; private set; } = new List<Notificacao>();

        protected void AdicionarNotificacao(string campo, string mensagem) => Notificacoes.Add(new Notificacao(campo, mensagem));

        protected void AdicionarNotificacoes(params Notificavel[] itensNotificaveis)
        {
            foreach (var item in itensNotificaveis)
                Notificacoes.AddRange(item.Notificacoes);
        }

        protected bool ObjetoValido() => Notificacoes.Count == 0;

        protected bool ObjetoInvalido() => Notificacoes.Count > 0;

        protected void LimparNotificacao() => Notificacoes.Clear();
    }

    public class Notificacao
    {
        public Notificacao(string campo, string mensagem)
        {
            Campo = campo;
            Mensagem = mensagem;
        }

        public string Campo { get; private set; }
        public string Mensagem { get; private set; }
    }
}
