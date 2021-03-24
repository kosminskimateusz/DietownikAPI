using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;

namespace Dietownik.ApplicationServices.Mappings
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            this.CreateMap<DataAccess.Entities.Product, Product>()
            .ForMember(model => model.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(model => model.Name, option => option.MapFrom(entity => entity.Name))
            .ForMember(model => model.Kcal, option => option.MapFrom(entity => entity.Kcal));
        }
    }
}