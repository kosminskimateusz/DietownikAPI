using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dietownik.DataAccess.Entities
{
    public class EntityIngredient : EntityBase
    {
        [Required]
        [NotNull]
        [Column(TypeName = "decimal(18,1)")]
        public decimal Weigth { get; set; }

        [Required]
        [NotNull]
        public int EntityProductId { get; set; }

        [Required]
        [NotNull]
        public int EntityRecipeId { get; set; }
    }
}