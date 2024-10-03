using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using Waqfi.WebUI.Filters;
using WebUI;
using WebUI.Filters;
using WebUI.Helpers;
using WebUI.Mapping;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddMvcOptions(_ =>
{
    _.Filters.Add<OnUserActionFilter>();
    _.Filters.Add<UIExceptionFilterAttribute>();
});

builder.Services.AddClientApis(builder.Configuration);
builder.Services.AddScoped<IAppSettingService, AppSettingService>();
//builder.Services.AddTransient<IClaimsTransformation, MyClaimsTransformation>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<WaqfiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddClientApis(builder.Configuration);


builder.Services.AddAutoMapper(typeof(MappingProfileWeb));


builder.Services.AddAuthentication("AuthCooKie").AddCookie("AuthCooKie", options =>
{
    options.Cookie.Name = "AuthCooKie";
    options.LoginPath = "/Admin/Login";
    options.AccessDeniedPath = "/Admin/AccessDenied";
    options.LogoutPath = "/Admin/Login";
    //options.ForwardSignOut = "AuthCooKie";
});




//var mapperConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new MappingProfileWeb());
//});

//IMapper mapper = mapperConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();


app.Use(async (context, next) =>
{
    bool isAjaxCall = context.Request.Headers["x-requested-with"] == "XMLHttpRequest";
    try
    {
        await next();
    }
    catch (UnauthorizedAccessException ex)
    {
        if (isAjaxCall)
        {
            await context.SignOutAsync("AuthCooKie");
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            
        }
        else
        {

            await context.SignOutAsync("AuthCooKie");
            context.Response.Redirect("/Admin/Login");
        }
    }

});


app.Run();

