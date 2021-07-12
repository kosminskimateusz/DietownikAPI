using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dietownik.DataAccess.Entities
{
    public class EntityProduct : EntityBase
    {
        [Required]
        [NotNull]
        [MaxLength(150)]
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

        public List<EntityIngredient> EntityIngredients { get; set; }

    }
}