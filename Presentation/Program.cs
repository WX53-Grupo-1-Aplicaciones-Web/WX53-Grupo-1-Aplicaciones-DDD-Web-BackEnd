using System.Reflection;
using Application.CommandServices.CustomerCommandService;
using Application.CommandServices.OrderCommandService;
using Application.CommandServices.ProductCommandService;
using Application.QueryServices.CustomerQueryService;
using Application.QueryServices.OrderQueryService;
using Application.QueryServices.ProductQueryService;
using Domain.Publishing.Models.Entities;
using Domain.Publishing.Repositories;
using Domain.Publishing.Services;
using Domain.Publishing.Services.OrderServices;
using Domain.Publishing.Services.ProductServices;
using Infrastructure.Publishing.Persistence;
using Infrastructure.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WX_53_Artisania.Mapper;
using WX_53_Artisania.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy", 
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Artisania API",
        Description = "Artisania API - Grupo 1 - Aplicaciones Web",
        TermsOfService = new Uri("https://artisania.azurewebsites.net/"),
        Contact = new OpenApiContact
        {
            Name = "Artisania - Landing Page",
            Url = new Uri("https://wx53-grupo-1-aplicaciones-web.github.io/WX53-Grupo-1-Aplicaciones-Web-LandingPage/")
        },
        License = new OpenApiLicense
        {
            Name = "Artisania Web Application",
            Url = new Uri("https://grupo-1-artisania-deployment.web.app/")
        }
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerCommandService, CustomerCommandService>();
builder.Services.AddScoped<ICustomerQueryService, CustomerQueryService>(); 

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryServices>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();

builder.Services.AddScoped<IEncryptService, EncryptCommandService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAutoMapper(typeof(RequestToModel), typeof(ModelToRequest), typeof(ModelToResponse));

var connectionString = builder.Configuration.GetConnectionString("ArtisaniaCenterConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<ArtisaniaDBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
        
        
    });

var app = builder.Build();
app.UseMiddleware<ErrorHandlerMiddleware>();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<ArtisaniaDBContext>())
{
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Artisania API v1");
    c.RoutePrefix = "swagger";  
});
app.UseCors("AllowAllPolicy");
//app.UseMiddleware<AuthenticationMiddlleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();