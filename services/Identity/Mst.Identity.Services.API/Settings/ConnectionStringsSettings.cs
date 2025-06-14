namespace External.API.Settings
{
    public class ConnectionStringsSettings(IConfiguration _configuration)
    {

        public string IntegrationSqlDb => _configuration.GetValue<string>("connectionStrings:IntegrationSqlDb")!;

        public string IntegrationSqlDbReadonly => _configuration.GetValue<string>("connectionStrings:IntegrationSqlDbReadonly")!;


    }
}
