using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using Dietownik.DataAccess.Entities;

namespace Dietownik.ApplicationServices.Mappings
{
    public class SavedRecipeProfile : Profile
    {
        public SavedRecipeProfile()
        {
            this.CreateMap<EntitySavedRecipe, ModelSavedRecipe>()
            .ForMember(model => model.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(model => model.PreferedKcal, option => option.MapFrom(entity => entity.PreferedKcal))
            .ForMember(model => model.RecipeId, option => option.MapFrom(entity => entity.EntityRecipeId))
            .ForMember(model => model.UserId, option => option.MapFrom(entity => entity.EntityUserId))
            .ForMember(model => model.Date, option => option.MapFrom(entity => entity.Date));

            this.CreateMap<AddSavedRecipeRequest, EntitySavedRecipe>()
            .ForMember(entity => entity.PreferedKcal, option => option.MapFrom(req => req.PreferedKcal))
            .ForMember(entity => entity.EntityRecipeId, option => option.MapFrom(req => req.RecipeId))
            .ForMember(entity => entity.EntityUserId, option => option.MapFrom(req => req.UserId))
            .ForMember(entity => entity.Date, option => option.MapFrom(req => req.Date));

            this.CreateMap<UpdateSavedRecipeRequest, EntitySavedRecipe>()
            .ForMember(entity => entity.Id, option => option.MapFrom(req => req.id))
            .ForMember(entity => entity.PreferedKcal, option => option.MapFrom(req => req.PreferedKcal));

            this.CreateMap<DeleteSavedRecipeRequest, EntitySavedRecipe>()
            .ForMember(entity => entity.Id, option => option.MapFrom(req => req.SavedRecipeId));
        }
    }
}