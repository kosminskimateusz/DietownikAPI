namespace Dietownik.Blazor.Models
{
    public class ModelProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Kcal { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbs { get; set; }
        public decimal Proteins { get; set; }
    }
}
