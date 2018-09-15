namespace lanches.crosscuting.Helper
{
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
