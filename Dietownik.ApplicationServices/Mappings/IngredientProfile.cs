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
            this.CreateMap<EntityIngredient, API.Domain.Models.ModelIngredient>()
            .ForMember(model => model.Id, opt => opt.MapFrom(entity => entity.Id))
            .ForMember(model => model.ProductId, opt => opt.MapFrom(entity => entity.ProductId))
            .ForMember(model => model.RecipeId, opt => opt.MapFrom(entity => entity.RecipeId))
            .ForMember(model => model.Weigth, opt => opt.MapFrom(entity => entity.Weigth));

            this.CreateMap<AddIngredientRequest, EntityIngredient>()
            .ForMember(ingredient => ingredient.RecipeId, option => option.MapFrom(request => request.RecipeId))
            .ForMember(ingredient => ingredient.ProductId, option => option.MapFrom(request => request.ProductId))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(request => request.Weigth));

            this.CreateMap<EntityIngredient, API.Domain.Models.ModelIngredient>()
            .ForMember(ingredient => ingredient.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(entity => entity.Weigth))
            .ForMember(ingredient => ingredient.ProductId, option => option.MapFrom(request => request.ProductId))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(request => request.Weigth));

            this.CreateMap<DeleteIngredientRequest, EntityIngredient>()
            .ForMember(ingredient => ingredient.Id, option => option.MapFrom(request => request.IngredientId));

            this.CreateMap<UpdateIngredientRequest, EntityIngredient>()
            .ForMember(ingredient => ingredient.Id, option => option.MapFrom(request => request.ingredientId))
            .ForMember(ingredient => ingredient.RecipeId, option => option.MapFrom(request => request.RecipeId))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(request => request.Weigth))
            .ForMember(ingredient => ingredient.ProductId, option => option.MapFrom(request => request.ProductId));
        }
    }
}