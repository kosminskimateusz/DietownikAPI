namespace Dietownik.ApplicationServices.API.Domain.Models
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public decimal Kcal { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbs { get; set; }
        public decimal Proteins { get; set; }

    }
}