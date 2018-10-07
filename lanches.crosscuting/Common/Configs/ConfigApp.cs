namespace lanches.crosscuting.Common.Configs
{
    public class ConfigApp
    {
        public MongoDb MongoDb { get; set; }
        public JwtAuth JwtAuth { get; set; }
        public string Environment { get; set; }
    }
}
