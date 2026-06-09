using Microsoft.EntityFrameworkCore;
using CatalogoCultural.API.Models;

namespace CatalogoCultural.API.Data
{
    /// <summary>
    /// A classe AppDbContext é a ponte entre a aplicação e o banco de dados.
    /// Ela herda de DbContext, que é a classe base do Entity Framework Core para trabalhar com bancos de dados.
    /// O Entity Framework Core é um ORM (Object-Relational Mapper) que facilita a manipulação de dados em bancos de dados relacionais usando objetos C#.
    /// O AppDbContext é configurado no Program.cs para usar um banco de dados específico (como SQL Server, SQLite, etc.) e para registrar os DbSets que representam as tabelas do banco de dados.
    /// </summary>
    /// <remarks>
    /// O AppDbContext é onde definimos as entidades que queremos mapear para o banco de dados. Cada DbSet representa uma tabela no banco de dados, e as propriedades da entidade representam as colunas dessa tabela.
    /// </remarks>
    public class AppDbContext : DbContext
    {
        // O construtor do AppDbContext recebe as opções de configuração do DbContext, que são passadas para a classe base.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // O DbSet<Evento> representa a tabela de eventos no banco de dados. Cada instância de Evento corresponde a uma linha nessa tabela.
        public DbSet<Evento> Eventos { get; set; }
    }
}