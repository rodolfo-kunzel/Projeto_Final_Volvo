using System.Text.Json.Serialization;using Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;
using Persistence.ContextDB;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

// builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


builder.Services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProjetoFinalDBContext>(
                context => context.UseSqlServer(config.GetConnectionString("Andre")) //Trocar para nome do usuário
            );
builder.Services.AddScoped<CaminhaoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ConcessionariaService>();
builder.Services.AddScoped<ModeloCaminhaoService>();
builder.Services.AddScoped<MontadoraService>();
builder.Services.AddScoped<PedidoService>();

builder.Services.AddScoped<GeralPersistence>();
builder.Services.AddScoped<CaminhaoPersistence>();
builder.Services.AddScoped<ClientePersistence>();
builder.Services.AddScoped<ConcessionariaPersistence>();
builder.Services.AddScoped<ModeloCaminhaoPersistence>();
builder.Services.AddScoped<MontadoraPersistence>();
builder.Services.AddScoped<PedidoPersistence>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddMvc().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
        var allErrors = context.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
        var errors = context.ActionDescriptor.DisplayName;
        
        foreach (var item in allErrors)
        {
            errors += $" {item} ,";
        }
        logger.LogError(errors);
        return new BadRequestObjectResult(context.ModelState);
    };
});

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(acess => acess.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

