namespace Mst.Identity.Services.API.Registers
{
    using Microsoft.OpenApi.Models;
    using Mst.Identity.Services.API.Settings;
    public static partial class Register
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            SwaggerSettings swaggerSettings = new(configuration);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(swaggerSettings.Version, new OpenApiInfo
                {
                    Title = swaggerSettings.ApplicationName,
                    Version = swaggerSettings.Version,
                    Description = swaggerSettings.Description
                });

                // Add GUID schema handling
                options.MapType<Guid>(() => new OpenApiSchema { Type = "string", Format = "uuid" });

                // If using XML comments (optional)
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath);
                }
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, IConfiguration configuration)
        {
            SwaggerSettings swaggerSettings = new(configuration);

            app.UseSwagger(c =>
            {
                c.RouteTemplate = swaggerSettings.RouteTemplate;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerSettings.Version1_0_JsonEndpointUrl, swaggerSettings.Version1_0_Name);
                c.RoutePrefix = swaggerSettings.RoutePrefix; // Access at route
            });

            return app;
        }
    }
}
