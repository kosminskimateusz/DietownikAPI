using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;

namespace Dietownik.ApplicationServices.Mappings
{
    public class RecipesProfile : Profile
    {
        public RecipesProfile()
        {
            this.CreateMap<DataAccess.Entities.Recipe, Recipe>()
            .ForMember(model => model.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(model => model.Name, option => option.MapFrom(entity => entity.Name));
        }
    }
}