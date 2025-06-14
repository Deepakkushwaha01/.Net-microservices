namespace External.API.Settings
{
    public class ConnectionStringsSettings(IConfiguration _configuration)
    {

        public string IntegrationSqlDb => _configuration.GetValue<string>("connectionStrings:MstSqlDb")!;

        public string IntegrationSqlDbReadonly => _configuration.GetValue<string>("connectionStrings:MstSqlDbReadonly")!;


    }
}
