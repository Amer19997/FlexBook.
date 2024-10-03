using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Interfaces.NotificationServices;
using FlexBook.Domain;
using FlexBook.Domain.Repositories;
using FlexBook.Infrastructure.Identity;
using FlexBook.Infrastructure.Persistence;
using FlexBook.Infrastructure.Persistence.Interceptors;
using FlexBook.Infrastructure.Persistence.Repositories;
using FlexBook.Infrastructure.Services;
using FlexBook.Infrastructure.Services.NotificationServices;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<FlexBookDbContext>(options =>
                options.UseInMemoryDatabase("FlexBookDb"));
        }
        else
        {
            services.AddDbContext<FlexBookDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(FlexBookDbContext).Assembly.FullName))
                            .LogTo(Console.WriteLine,LogLevel.Information).EnableSensitiveDataLogging());
        }
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<IEmailProviderSender, EmailProviderSender>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddSingleton<ITokenService, TokenService>();
        services.Configure<AppSettings>(options => configuration.GetSection("AppSettings").Bind(options));
        
        services.AddScoped<IAccountService,AccountService>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IUnivesityRepository, UnivesityRepository>();
        services.AddScoped<IFacultyRepository, FacultyRepository>();
        services.AddScoped<ICouresRepository, CouresRepository>();
        services.AddScoped<IInterestsListRepository, InterestsListRepository>();
        return services;
    }
}
