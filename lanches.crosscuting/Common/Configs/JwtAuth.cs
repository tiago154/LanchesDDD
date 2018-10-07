namespace lanches.crosscuting.Common.Configs
{
    public class JwtAuth
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TimeExpirationHours { get; set; }
    }
}
