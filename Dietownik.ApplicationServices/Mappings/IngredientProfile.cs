using System.Collections.Generic;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.DataAccess.Entities;

namespace Dietownik.ApplicationServices.Mappings
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            this.CreateMap<EntityIngredient, ModelIngredient>()
            .ForMember(model => model.Id, opt => opt.MapFrom(entity => entity.Id))
            .ForMember(model => model.ProductId, opt => opt.MapFrom(entity => entity.EntityProductId))
            .ForMember(model => model.RecipeId, opt => opt.MapFrom(entity => entity.EntityRecipeId))
            .ForMember(model => model.Weigth, opt => opt.MapFrom(entity => entity.Weigth))
            .ForMember(model => model.Name, opt => opt.MapFrom(entity => entity.Product.Name));

            this.CreateMap<AddIngredientRequest, EntityIngredient>()
            .ForMember(ingredient => ingredient.EntityRecipeId, option => option.MapFrom(request => request.RecipeId))
            .ForMember(ingredient => ingredient.EntityProductId, option => option.MapFrom(request => request.ProductId))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(request => request.Weigth));

            this.CreateMap<DeleteIngredientRequest, EntityIngredient>()
            .ForMember(ingredient => ingredient.Id, option => option.MapFrom(request => request.IngredientId));

            this.CreateMap<UpdateIngredientRequest, EntityIngredient>()
            .ForMember(ingredient => ingredient.Id, option => option.MapFrom(request => request.ingredientId))
            .ForMember(ingredient => ingredient.EntityRecipeId, option => option.MapFrom(request => request.RecipeId))
            .ForMember(ingredient => ingredient.Weigth, option => option.MapFrom(request => request.Weigth))
            .ForMember(ingredient => ingredient.EntityProductId, option => option.MapFrom(request => request.ProductId));
        }
    }
}