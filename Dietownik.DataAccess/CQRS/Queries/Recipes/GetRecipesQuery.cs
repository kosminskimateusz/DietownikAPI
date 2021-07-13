using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Recipes
{
    public class GetRecipesQuery : QueryBase<List<EntityRecipe>>
    {
        public string SearchPhrase { get; set; }
        public override Task<List<EntityRecipe>> Execute(RecipeStorageContext context)
        {
            // List<EntityIngredient> ingredients = context.Ingredients.ToList();
            // List<EntityProduct> products = context.Products.ToList();
            // List<EntityRecipe> recipes = context.Recipes.ToList();

            // var multipeTable = from p in products
            //                    join ing in ingredients on p.Id equals ing.EntityProductId into table1
            //                    from ing in table1.DefaultIfEmpty()
            //                    join rec in recipes on ing.EntityRecipeId equals rec.Id into table2
            //                    from rec in table2.DefaultIfEmpty()
            //                    select new MultipleClass { products = p, ingredients = ing, recipes = rec };

            // var result = context.Ingredients.Join(context.Products,
            //                                     ing => ing.EntityProductId,
            //                                     prod => prod.Id,
            //                                     (ing, prod) => new { ing, prod })
            //                                     .Join(context.Recipes,
            //                                     ing2 => ing2.ing.EntityRecipeId,
            //                                     rec => rec.Id,
            //                                     (ing2, rec) => new { ing2, rec }).ToListAsync();

            // var res = context.Recipes.Include("EntityIngredients").ToListAsync();

            // var ing = context.Ingredients.Include(x => x.EntityProductId).Include(x => x.EntityRecipeId);
            // return res;

            if (this.SearchPhrase == null)
                return context.Recipes
                .Include(x => x.EntityIngredients)
                .ToListAsync();

            return context.Recipes
            .Where(recipe => recipe.Name.Contains(this.SearchPhrase))
            .Include(x => x.EntityIngredients).ThenInclude(xs => xs.Product)
            .ToListAsync();
        }
    }
}