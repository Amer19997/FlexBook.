using System.Reflection;
using System.Text;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Resources;
using Serilog;
using FlexBook.Application;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebAPIServices();
builder.Services.AddResourceService();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
    {
        var lang = context.Request.Headers["Accept-Language"].ToString()?.Split(',')?.FirstOrDefault() ?? "ar";
        return Task.FromResult(new ProviderCultureResult(lang, lang))!;
    }));
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
   
});

builder.Services.AddSingleton<HostNamesConfiguration>();

string conncetionstring = builder.Configuration["ConnectionStrings:DefaultConnection"]!;


builder.Services.AddHangfire(x => x.UseSqlServerStorage(conncetionstring));
builder.Services.AddHangfireServer();




string encKey = builder.Configuration["AppSettings:JwtSettings:JwtEncryptionKey"]!;
string issuer = builder.Configuration["AppSettings:JwtSettings:Issuer"]!;
string audience = builder.Configuration["AppSettings:JwtSettings:Audience"]!;

builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(jwtOptions =>
            {
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.SaveToken = false;
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(encKey)),
                    ClockSkew = TimeSpan.Zero
                };
                jwtOptions.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        // Call this to skip the default logic and avoid using the default response
                        context.HandleResponse();

                        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/problem+json; charset=utf-8";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            status = StatusCodes.Status401Unauthorized,
                            title = "Unauthorized",
                            type = "https://tools.ietf.org/html/rfc7235#section-3.1"
                        }));
                    }
                };

            });

builder.Services.AddMemoryCache();


Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.ConfigureAppConfiguration((hostContext, config) =>
{
    config.SetBasePath(Directory.GetCurrentDirectory());
    config.AddJsonFile("appsettings.json", false, true);
    config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
    config.AddCommandLine(args);

}).UseSerilog();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Lax;

});

var app = builder.Build();

app.UseMiddleware<HostValidationMiddleware>();



// Configure the HTTP request pipeline.


app.UseStaticFiles(new StaticFileOptions{});

string templateEmailPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\TemplateEmail");
if (!Directory.Exists(templateEmailPath))
    Directory.CreateDirectory(templateEmailPath);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                           Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/TemplateEmail")),
    RequestPath = new PathString("/TemplateEmail")
});


var swagger = builder.Configuration["Swagger:ShowSwaggerUI"];
if (swagger.Contains("true",StringComparison.OrdinalIgnoreCase))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

//hangFire
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "FlexBook Dashboard"
});


var cancellationToken = new CancellationToken();




app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

var SupportedCultures = new[] { "ar", "en" };
app.UseRequestLocalization(
    new RequestLocalizationOptions()
    .SetDefaultCulture(SupportedCultures[0])
    .AddSupportedCultures(SupportedCultures)
    .AddSupportedUICultures(SupportedCultures));

app.Run();

