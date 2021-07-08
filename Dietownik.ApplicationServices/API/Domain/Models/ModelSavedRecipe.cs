using System;

namespace Dietownik.ApplicationServices.API.Domain.Models
{
    public class ModelSavedRecipe : ModelBase
    {
        public decimal PreferedKcal { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}