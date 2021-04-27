using System;
using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.SavedRecipes
{
    public class AddSavedRecipeRequest : IRequest<AddSavedRecipeResponse>
    {
        public decimal PreferedKcal { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}