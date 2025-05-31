namespace Mst.Identity.Services.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                RunApplication(BuildApplication(WebApplication.CreateBuilder(args)));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static WebApplication BuildApplication(WebApplicationBuilder builder)
        {
            return builder.Build();
        }

        public static void RunApplication(WebApplication app)
        {
            app.MapGet("/", () => Results.Ok("Welcome to Identity Service API"));
            app.Run();
        }
    }
}
