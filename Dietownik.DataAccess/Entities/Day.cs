using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Dietownik.DataAccess.Entities
{
    public class Day : EntityBase
    {
        [Required]
        [NotNull]
        public DateTime Date { get; set; }
        [Required]
        [NotNull]
        public int UserId { get; set; }
        public List<SavedRecipe> SavedRecipes { get; set; } // maximum 5 recipes
    }
}