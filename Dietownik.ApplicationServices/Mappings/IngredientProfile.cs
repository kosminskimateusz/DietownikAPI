using System.Collections.Generic;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using Dietownik.DataAccess.Entities;

namespace Dietownik.ApplicationServices.Mappings
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            this.CreateMap<Ingredient, API.Domain.Models.Ingredient>()
            .ForMember(model => model.Id, opt => opt.MapFrom(entity => entity.Id))
            .ForMember(model => model.ProductId, opt => opt.MapFrom(entity => entity.ProductId))
            .ForMember(model => model.RecipeId, opt => opt.MapFrom(entity => entity.RecipeId))
            .ForMember(model => model.Weigth, opt => opt.MapFrom(entity => entity.Weigth));

            this.CreateMap<AddIngredientRequest, Ingredient>()
            .ForMember(ingredient => ingredient.RecipeId, option => option.MapFrom(request => request.RecipeId))
            .ForMember(ingredient => ingredient.ProductId, option => option.MapFrom(request => request.ProductId))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(request => request.Weigth));

            this.CreateMap<Ingredient, ApplicationServices.API.Domain.Models.Ingredient>()
            .ForMember(ingredient => ingredient.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(entity => entity.Weigth))
            .ForMember(ingredient => ingredient.ProductId, option => option.MapFrom(request => request.ProductId))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(request => request.Weigth));

            this.CreateMap<DeleteIngredientRequest, Ingredient>()
            .ForMember(ingredient => ingredient.Id, option => option.MapFrom(request => request.IngredientId));
        }
    }
}