using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.DataAccess.Entities;

namespace Dietownik.ApplicationServices.Mappings
{
    public class RecipesProfile : Profile
    {
        public RecipesProfile()
        {
            this.CreateMap<EntityRecipe, ModelRecipe>()
            .ForMember(model => model.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(model => model.Name, option => option.MapFrom(entity => entity.Name))
            .ForMember(model => model.Ingredients, option => option.MapFrom(entity => entity.EntityIngredients != null ? entity.EntityIngredients : new List<EntityIngredient>()));

            this.CreateMap<AddRecipeRequest, EntityRecipe>()
            .ForMember(entity => entity.Name, option => option.MapFrom(request => request.Name));

            this.CreateMap<DeleteRecipeRequest, EntityRecipe>()
            .ForMember(entity => entity.Id, option => option.MapFrom(request => request.RecipeId));

            this.CreateMap<UpdateRecipeRequest, EntityRecipe>()
            .ForMember(entity => entity.Id, option => option.MapFrom(request => request.recipeId))
            .ForMember(entity => entity.Name, option => option.MapFrom(request => request.Name));
        }
    }
}