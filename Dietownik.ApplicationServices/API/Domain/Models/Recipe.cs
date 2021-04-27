using System.Collections.Generic;

namespace Dietownik.ApplicationServices.API.Domain.Models
{
    public class Recipe : ModelBase
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public decimal Kcal { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbs { get; set; }
        public decimal Proteins { get; set; }
    }
}