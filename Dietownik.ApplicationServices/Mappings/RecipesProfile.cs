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
            .ForMember(model => model.Ingredients, option => option.MapFrom(entity => entity.EntityIngredients.Select(x => x.Product.Name) != null ? entity.EntityIngredients : new List<EntityIngredient>()))
            .ForMember(model => model.Kcal, option => option.MapFrom(entity => entity.EntityIngredients.Select(x => (x.Product.Kcal * x.Weigth) / 100).Sum()))
            .ForMember(model => model.Fats, option => option.MapFrom(entity => entity.EntityIngredients.Select(x => (x.Product.Fats * x.Weigth) / 100).Sum()))
            .ForMember(model => model.Carbs, option => option.MapFrom(entity => entity.EntityIngredients.Select(x => (x.Product.Carbs * x.Weigth) / 100).Sum()))
            .ForMember(model => model.Proteins, option => option.MapFrom(entity => entity.EntityIngredients.Select(x => (x.Product.Proteins * x.Weigth) / 100).Sum()));

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