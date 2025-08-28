using Acapra.Application.Interfaces;
using Acapra.Application.Services;
using Acapra.Domain.Interfaces.Repositories;
using Acapra.Infra.Context;
using Acapra.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do Entity Framework com PostgreSQL
builder.Services.AddDbContext<AcapraDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DataBase"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DataBase"))));
//builder.Configuration.GetConnectionString("DataBase")

builder.Services.AddScoped<IDbConnection>(provider =>
        new MySqlConnection(builder.Configuration.GetConnectionString("DataBase")));

//registrando os servi�os e repositorios
builder.Services.AddScoped<IExemploRepository, ExemploRepository>();
builder.Services.AddScoped<IExemploService, ExemploService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
