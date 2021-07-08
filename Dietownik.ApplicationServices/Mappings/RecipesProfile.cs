using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Recipes;

namespace Dietownik.ApplicationServices.Mappings
{
    public class RecipesProfile : Profile
    {
        public RecipesProfile()
        {
            this.CreateMap<DataAccess.Entities.EntityRecipe, ModelRecipe>()
            .ForMember(model => model.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(model => model.Name, option => option.MapFrom(entity => entity.Name))
            .ForMember(model => model.Ingredients, option => option.MapFrom(entity => entity.Ingredients));

            this.CreateMap<AddRecipeRequest, DataAccess.Entities.EntityRecipe>()
            .ForMember(entity => entity.Name, option => option.MapFrom(request => request.Name));

            this.CreateMap<DeleteRecipeRequest, DataAccess.Entities.EntityRecipe>()
            .ForMember(entity => entity.Id, option => option.MapFrom(request => request.RecipeId));

            this.CreateMap<UpdateRecipeRequest, DataAccess.Entities.EntityRecipe>()
            .ForMember(entity => entity.Id, option => option.MapFrom(request => request.recipeId))
            .ForMember(entity => entity.Name, option => option.MapFrom(request => request.Name));
        }
    }
}