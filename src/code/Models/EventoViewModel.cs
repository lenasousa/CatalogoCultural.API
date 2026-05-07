using System.Text.Json.Serialization;

namespace CatalogoCultural.API.ViewModels
{
    /// <summary>
    /// ViewModel para representar os dados de um evento cultural.
    /// </summary>
    public class EventoViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("tipo")]
        public string? Tipo { get; set; }

        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }

        [JsonPropertyName("endereco")]
        public string? Endereco { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("zona")]
        public string? Zona { get; set; }

        [JsonPropertyName("gratuito")]
        public bool Gratuito { get; set; }

        [JsonPropertyName("valor")]
        public string? Valor { get; set; }

        [JsonPropertyName("data")]
        public string? Data { get; set; }

        [JsonPropertyName("imagem")]
        public string? Imagem { get; set; }

        [JsonPropertyName("site")]
        public string? Site { get; set; }

        [JsonPropertyName("destaques")]
        public List<string>? Destaques { get; set; }
    }
}