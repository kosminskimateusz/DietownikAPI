using System.Collections.Generic;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Recipes
{
    public class UpdateRecipeRequest : IRequest<UpdateRecipeResponse>
    {
        public int recipeId;
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }

    }
}