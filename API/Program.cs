using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;
using Persistence.ContextDB;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProjetoFinalDBContext>(
                context => context.UseSqlServer(config.GetConnectionString("Andre")) //Trocar para nome do usuário
            );
builder.Services.AddScoped<MontadoraService>();

builder.Services.AddScoped<GeralPersistence>();
builder.Services.AddScoped<MontadoraPersistence>();

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

