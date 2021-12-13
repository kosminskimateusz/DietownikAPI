using System.Text.Json.Serialization;

namespace Dietownik.Blazor.Model
{
    public class Data
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

// {"data":[{"name":"Papryka","kcal":10.0,"fats":0.0,"carbs":8.0,"proteins":0.0,"id":1}],"error":null}