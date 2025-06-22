namespace Mst.API.Registers
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Mst.Core.Commands;
    using Mst.Core.Query;

    public static partial class Register
    {
        public static IServiceCollection RegisterMediatR(this IServiceCollection services) => services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CommandsAssemblyMarker>();
            cfg.RegisterServicesFromAssemblyContaining<QueriesAssemblyMarker>();
        });
    }
}
