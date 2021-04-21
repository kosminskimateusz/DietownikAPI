using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dietownik.DataAccess.Entities
{
    public class SavedRecipe : EntityBase
    {
        [Required]
        [NotNull]
        [Column(TypeName = "decimal(18,1)")]
        public decimal PreferedKcal { get; set; }
        [Required]
        [NotNull]
        public int RecipeId { get; set; }
        [Required]
        [NotNull]
        public int DayId { get; set; }

    }
}