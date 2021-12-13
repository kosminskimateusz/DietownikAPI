using System.Text.Json.Serialization;

namespace Dietownik.Blazor.Model
{
    public class Product
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}

