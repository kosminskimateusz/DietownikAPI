using System.Text.Json.Serialization;

namespace Dietownik.Blazor.Models
{
    public class Product
    { 
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public decimal Kcal { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbs { get; set; }
        public decimal Proteins { get; set; }
    }
}

