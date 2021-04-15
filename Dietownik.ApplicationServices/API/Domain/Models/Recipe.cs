using System.Collections.Generic;

namespace Dietownik.ApplicationServices.API.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public decimal KcalFull { get; set; }
        public decimal FatsFull { get; set; }
        public decimal CarbsFull { get; set; }
        public decimal ProteinsFull { get; set; }
    }
}