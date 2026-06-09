using Microsoft.EntityFrameworkCore;
using CatalogoCultural.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços para a API e para a documentação (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CatalogoCulturalDB"));
    // futuramente, para quando for implementado o PostgreSQL, vou substitutir a linha acima por:
    // options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Comando que faz a API rodar e ficar escutando requisições
app.Run();