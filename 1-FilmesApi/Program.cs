using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using FilmesApi.Data;
using AutoMapper;
using FilmesApi.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<OracleDbContext>(opt => opt
    .UseLazyLoadingProxies()
    .UseOracle(builder.Configuration.GetConnectionString("OracleContext")));

builder.Services.AddAutoMapper(config => {
    config.AddProfile<FilmeProfile>();
    config.AddProfile<CinemaProfile>();
    config.AddProfile<EnderecoProfile>();
    config.AddProfile<GerenteProfile>();
    config.AddProfile<SessaoProfile>();
 });

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
