using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dietownik.DataAccess.Entities
{
    public class Ingredient : EntityBase
    {
        [Required]
        [Column(TypeName = "decimal(18,1)")]
        public decimal Weigth { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int RecipeId { get; set; }
    }
}