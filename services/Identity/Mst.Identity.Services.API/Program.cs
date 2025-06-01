namespace Mst.Identity.Services.API
{
    using Mst.Identity.Services.API.Extensions;
    using Mst.Identity.Services.API.Settings;
    using Swashbuckle.AspNetCore.SwaggerUI;
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
            return builder.Build();
        }

        public static void RunApplication(WebApplication app)
        {
            app.MapGet("/", () => Results.Ok("Welcome to Identity Service API"));
            app.MapControllers();
            app.UseSwaggerDocumentation(app.Configuration);
            app.Run();
        }
    }
}
