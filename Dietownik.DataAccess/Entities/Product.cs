using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dietownik.DataAccess.Entities
{
    public class Product : EntityBase
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,1")]
        public decimal Kcal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,1")]
        public decimal Fats { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,1")]
        public decimal Carbs { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,1")]
        public decimal Proteins { get; set; }

        public List<Ingredient> Ingredients { get; set; }

    }
}