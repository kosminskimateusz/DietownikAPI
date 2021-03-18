using System.Collections.Generic;

namespace Dietownik.ApplicationServices.API.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}