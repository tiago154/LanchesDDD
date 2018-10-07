namespace lanches.crosscuting.Common.Configs
{
    public class MongoDb
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string AuthenticationDatabase { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int MinConnectionPoolSize { get; set; }
        public int MaxConnectionPoolSize { get; set; }
    }
}
