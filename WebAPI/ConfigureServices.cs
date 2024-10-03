using Microsoft.AspNetCore.Mvc;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Infrastructure.Persistence;
using FlexBook.WebAPI.Filters;
using FlexBook.WebAPI.Services;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddRazorPages().AddMvcOptions(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>());
               // .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        AddSwaggerDocumentation(services);

      
        return services;
    }

    static void AddSwaggerDocumentation(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            //This is to generate the Default UI of Swagger Documentation  
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "FlexBook",
                Description = "FlexBook.APIs"

            });
            // To Enable authorization using Swagger (JWT)  
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    },

                });

        });
    }
}
