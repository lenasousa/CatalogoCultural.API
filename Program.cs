using Microsoft.EntityFrameworkCore;
using CatalogoCultural.API.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURAÇÃO DO CORS: Permite que o Angular acesse esta API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CatalogoCulturalDB"));
    // futuramente, para quando for implementado o PostgreSQL, vou substituir a linha acima por:
    // options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// =========================================================
// CARGA INICIAL DE DADOS (SEEDER)
// Cria um escopo temporário para usar a injeção de dependência e rodar o nosso Seeder
// =========================================================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    // O DataSeeder vai usar o AppDbContext para inserir os 30+ eventos
    DataSeeder.Initialize(services);
}
// =========================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 2. ATIVAÇÃO DO CORS: Deve ficar obrigatoriamente antes de MapControllers
app.UseCors("AllowAngularApp");

// O redirecionamento HTTPS fica desativado para testes locais rápidos
// app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();