namespace CatalogoCultural.API.Models
{
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