using AutoMapper;
using Dietownik.DataAccess.Entities;

namespace Dietownik.ApplicationServices.Mappings
{
    public class SavedRecipeProfile : Profile
    {
        public SavedRecipeProfile()
        {
            this.CreateMap<SavedRecipe, API.Domain.Models.SavedRecipe>()
            .ForMember(model => model.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(model => model.PreferedKcal, option => option.MapFrom(entity => entity.PreferedKcal))
            .ForMember(model => model.RecipeId, option => option.MapFrom(entity => entity.RecipeId))
            .ForMember(model => model.UserId, option => option.MapFrom(entity => entity.UserId))
            .ForMember(model => model.Date, option => option.MapFrom(entity => entity.Date));
        }
    }
}