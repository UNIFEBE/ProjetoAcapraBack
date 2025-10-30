using Acapra.Application.Interfaces;
using Acapra.Application.Services;
using Acapra.Domain.Interfaces.Repositories;
using Acapra.Infra.Context;
using Acapra.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System.Data;
using System.Text.Json.Serialization;
using AutoMapper;
using Acapra.Domain.Interfaces.Dapper;
using Vendas.Infra.Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.WithOrigins("*") // ou "*" para liberar todos
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

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

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IFormularioPerguntaRepository, FormularioPerguntaRepository>();
builder.Services.AddScoped<IFormularioPerguntaService, FormularioPerguntaService>();
builder.Services.AddScoped<IFormularioRespostasRepository, FormularioRespostasRepository>();
builder.Services.AddScoped<IFormularioRespostasServices, FormularioRespostasService>();
builder.Services.AddScoped<IDapperAcapra, DapperAcapra>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
