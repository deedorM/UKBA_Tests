namespace UKBA_TestExploration.Config
{
    public class readFromConfig
    {
        private IConfigurationRoot _config;
        public readFromConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json");

            _config = builder.Build();
        }

        public string GetJsonData(string key) => _config[key]!;
    }
}