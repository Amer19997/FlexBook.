using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Waqfi.LocalNIC.Persistence;

namespace LocalNIC;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureLocalNICServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NICDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("NICDbContext"),
                   builder => builder.MigrationsAssembly(typeof(NICDbContext).Assembly.FullName)));

        services.AddScoped<NICDbContext, NICDbContext>();
        return services;
    }
}
