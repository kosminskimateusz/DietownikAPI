using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.SavedRecipes
{
    public class GetSavedRecipesQuery : QueryBase<List<SavedRecipe>>
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public override Task<List<SavedRecipe>> Execute(RecipeStorageContext context)
        {
            if (this.UserId == 0 && this.Date == null)
                return context.SavedRecipes.ToListAsync();
            else if (this.UserId != 0 && this.Date == null)
                return context.SavedRecipes.Where(recipe => recipe.UserId == this.UserId).ToListAsync();
            else if (this.UserId == 0 && this.Date != null)
                return context.SavedRecipes.Where(recipe => recipe.Date == this.Date).ToListAsync();
            else
                return context.SavedRecipes.Where(recipe => recipe.UserId == this.UserId)
                .Where(recipe => recipe.Date == this.Date).ToListAsync();
        }
    }
}