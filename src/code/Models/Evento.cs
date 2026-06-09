namespace CatalogoCultural.API.Models
{
    /// <summary>
    /// A classe Evento representa a estrutura dos dados de um evento cultural. Ela contém propriedades que correspondem às informações relevantes sobre um evento, como nome, tipo, localização, descrição, data, etc.
    /// Cada propriedade da classe Evento corresponde a uma coluna na tabela de eventos do banco de dados
    /// e é usada para mapear os dados do banco de dados para objetos C# que podem ser manipulados na aplicação.
    /// </summary>
    /// <remarks>
    /// A classe Evento é uma entidade do domínio da aplicação, e é usada para representar os eventos culturais que serão armazenados e manipulados no banco de dados. Ela é mapeada para a tabela "Eventos" no banco de dados através do DbSet<Evento> definido no AppDbContext.
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Zona { get; set; } = string.Empty;
        public bool Gratuito { get; set; }
        public string Valor { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public string Imagem { get; set; } = string.Empty;
        public string Site { get; set; } = string.Empty;
        public List<string>? Destaques { get; set; }
    }
}