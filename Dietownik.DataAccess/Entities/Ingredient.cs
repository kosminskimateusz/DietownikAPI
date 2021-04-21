using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dietownik.DataAccess.Entities
{
    public class Ingredient : EntityBase
    {
        [Required]
        [NotNull]
        [Column(TypeName = "decimal(18,1)")]
        public decimal Weigth { get; set; }
        [Required]
        [NotNull]
        public int ProductId { get; set; }
        [Required]
        [NotNull]
        public int RecipeId { get; set; }
    }
}