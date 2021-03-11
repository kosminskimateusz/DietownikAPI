using System.ComponentModel.DataAnnotations;

namespace Dietownik.DataAccess.Entities
{
    public class Ingredient : EntityBase
    {
        [Required]
        public decimal Weigth { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int RecipeId { get; set; }
    }
}