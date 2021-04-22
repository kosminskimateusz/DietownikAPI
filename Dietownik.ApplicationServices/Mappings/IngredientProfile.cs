using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using Dietownik.DataAccess.Entities;

namespace Dietownik.ApplicationServices.Mappings
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            this.CreateMap<AddIngredientRequest, Ingredient>()
            .ForMember(ingredient => ingredient.RecipeId, option => option.MapFrom(request => request.RecipeId))
            .ForMember(ingredient => ingredient.ProductId, option => option.MapFrom(request => request.ProductId))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(request => request.Weigth));

            this.CreateMap<Ingredient, ApplicationServices.API.Domain.Models.Ingredient>()
            .ForMember(ingredient => ingredient.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(entity => entity.Weigth))
            .ForMember(ingredient => ingredient.ProductId, option => option.MapFrom(request => request.ProductId))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(request => request.Weigth));
        }
    }
}