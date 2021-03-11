using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dietownik.DataAccess.Entities
{
    public class Product : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Kcal { get; set; }

        [Required]
        public decimal FatsPerHundredGrams { get; set; }

        [Required]
        public decimal CarbsPerHundredGrams { get; set; }

        [Required]
        public decimal ProteinsPerHundredGrams { get; set; }

        public List<Ingredient> Ingredients { get; set; }

    }
}