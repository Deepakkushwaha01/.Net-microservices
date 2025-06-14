

namespace Mst.Identity.Services.API
{
    using External.API.Registers;
    using Mst.Identity.Services.API.Registers;
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                var app = BuildApplication(builder);
                RunApplication(app);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static WebApplication BuildApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddSwaggerDocumentation(builder.Configuration);
            builder.Services.RegisterDatabase(builder.Configuration);

            return builder.Build();
        }

        public static void RunApplication(WebApplication app)
        {
            app.MapGet("/", () => Results.Ok("Welcome to Identity Service API"));
            app.MapControllers();
            app.UseDatabaseHealthCheck();
            app.UseSwaggerDocumentation(app.Configuration);
            app.Run();
        }
    }
}
