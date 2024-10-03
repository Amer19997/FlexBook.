using System.Resources;

namespace WebUI;

using Resources;
using Waqfi.Application.Common.Interfaces;
using WebUI.Client;
using WebUI.IntegrationServices;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

public static class DependencyInjection
{
    public static IServiceCollection AddClientApis(this IServiceCollection services,
       ConfigurationManager configuration)
    {
        var clientApiUrl = configuration.GetSection("AppSettings").GetValue<string>("ApiUrl");
        services.AddScoped<UserActionInfoService>();
        services.AddScoped<CacheService>();
        services.AddHttpContextAccessor();

        services.AddHttpClient<IQuestionsClient, QuestionsClient>(client =>
            client.BaseAddress = new Uri(clientApiUrl))
            .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IContactUsClient, ContactUsClient>(client =>
           client.BaseAddress = new Uri(clientApiUrl))
           .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IDonatorClient, DonatorClient>(client =>
           client.BaseAddress = new Uri(clientApiUrl))
             .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();


        services.AddHttpClient<IUsersClient, UsersClient>(client =>
          client.BaseAddress = new Uri(clientApiUrl))
              .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IRolesClient, RolesClient>(client =>
           client.BaseAddress = new Uri(clientApiUrl))
              .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IWaqfyContentClient, WaqfyContentClient>(client =>
       client.BaseAddress = new Uri(clientApiUrl))
          .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();


        services.AddScoped<IResourceService, ResourceService>();


        services.AddHttpClient<IAuthClient, AuthClient>(client =>
          client.BaseAddress = new Uri(clientApiUrl));

        services.AddHttpClient<IAssociationsClient, AssociationsClient>(client =>
         client.BaseAddress = new Uri(clientApiUrl))
             .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<ISocietyClient, SocietyClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
              .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IProviderClient, ProviderClient>(client =>
         client.BaseAddress = new Uri(clientApiUrl))
              .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();


        services.AddHttpClient<ISeasonsClient, SeasonsClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
              .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IProductUnitClient, ProductUnitClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
              .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<ILookUpClient, LookUpClient>(client =>
         client.BaseAddress = new Uri(clientApiUrl))
              .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IProductClient, ProductClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
            .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();
        services.AddHttpClient<ISiteContentClient, SiteContentClient>(client =>
       client.BaseAddress = new Uri(clientApiUrl))
             .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();


        services.AddHttpClient<IBannerClient, BannerClient>(client =>
     client.BaseAddress = new Uri(clientApiUrl))
          .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<INewsClient, NewsClient>(client =>
       client.BaseAddress = new Uri(clientApiUrl))
           .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IProduectBannerClient, ProduectBannerClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
       .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<INetworkDonatorClient, NetworkDonatorClient>(client =>
       client.BaseAddress = new Uri(clientApiUrl))
      .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IPaymentClient, PaymentClient>(client =>
      client.BaseAddress = new Uri(clientApiUrl))
     .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IAwqafProductClient, AwqafProductClient>(client =>
     client.BaseAddress = new Uri(clientApiUrl))
    .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();


        services.AddHttpClient<IPaymentClient, PaymentClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
        .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IAwqafProductClient, AwqafProductClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
        .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();


         services.AddHttpClient<IAwqafProductClient, AwqafProductClient>(client =>
         client.BaseAddress = new Uri(clientApiUrl))
        .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<ITopGiversClient, TopGiversClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
        .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();


        services.AddHttpClient<IOfflineDonationClient, OfflineDonationClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
        .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

        services.AddHttpClient<IReportClient, ReportClient>(client =>
   client.BaseAddress = new Uri(clientApiUrl))
   .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();


        services.AddHttpClient<IReportsClient, ReportsClient>(client =>
        client.BaseAddress = new Uri(clientApiUrl))
        .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();


        services.AddTransient<ProtectedApiBearerTokenHandler>();

        return services;
    }
}
