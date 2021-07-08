using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using Dietownik.DataAccess.Entities;

namespace Dietownik.ApplicationServices.Mappings
{
    public class SavedRecipeProfile : Profile
    {
        public SavedRecipeProfile()
        {
            this.CreateMap<EntitySavedRecipe, API.Domain.Models.ModelSavedRecipe>()
            .ForMember(model => model.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(model => model.PreferedKcal, option => option.MapFrom(entity => entity.PreferedKcal))
            .ForMember(model => model.RecipeId, option => option.MapFrom(entity => entity.RecipeId))
            .ForMember(model => model.UserId, option => option.MapFrom(entity => entity.UserId))
            .ForMember(model => model.Date, option => option.MapFrom(entity => entity.Date));

            this.CreateMap<AddSavedRecipeRequest, EntitySavedRecipe>()
            .ForMember(entity => entity.PreferedKcal, option => option.MapFrom(req => req.PreferedKcal))
            .ForMember(entity => entity.RecipeId, option => option.MapFrom(req => req.RecipeId))
            .ForMember(entity => entity.UserId, option => option.MapFrom(req => req.UserId))
            .ForMember(entity => entity.Date, option => option.MapFrom(req => req.Date));

            this.CreateMap<UpdateSavedRecipeRequest, EntitySavedRecipe>()
            .ForMember(entity => entity.Id, option => option.MapFrom(req => req.id))
            .ForMember(entity => entity.PreferedKcal, option => option.MapFrom(req => req.PreferedKcal));

            this.CreateMap<DeleteSavedRecipeRequest, EntitySavedRecipe>()
            .ForMember(entity => entity.Id, option => option.MapFrom(req => req.SavedRecipeId));
        }
    }
}