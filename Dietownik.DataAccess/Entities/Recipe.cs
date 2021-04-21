using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dietownik.DataAccess.Entities
{
    public class Recipe : EntityBase
    {
        [Required]
        [NotNull]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,1)")]
        public decimal Kcal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,1)")]
        public decimal Fats { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,1)")]
        public decimal Carbs { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,1)")]
        public decimal Proteins { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public List<SavedRecipe> SavedRecipes { get; set; }

        // public int UserProfileId { get; set; } // Profile
    }
}