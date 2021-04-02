using AutoMapper;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.ApplicationServices.API.Domain.Models;

namespace Dietownik.ApplicationServices.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<DataAccess.Entities.Product, Product>()
            .ForMember(model => model.Id, option => option.MapFrom(entity => entity.Id))
            .ForMember(model => model.Name, option => option.MapFrom(entity => entity.Name))
            .ForMember(model => model.Kcal, option => option.MapFrom(entity => entity.Kcal));

            this.CreateMap<AddProductRequest, DataAccess.Entities.Product>()
            .ForMember(entity => entity.Name, option => option.MapFrom(request => request.Name))
            .ForMember(entity => entity.Kcal, option => option.MapFrom(request => request.Kcal))
            .ForMember(entity => entity.FatsPerHundredGrams, option => option.MapFrom(request => request.FatsPerHundredGramms))
            .ForMember(entity => entity.CarbsPerHundredGrams, option => option.MapFrom(request => request.CarbsPerHundredGrams))
            .ForMember(entity => entity.ProteinsPerHundredGrams, option => option.MapFrom(request => request.ProteinsPerHundredGrams));

            this.CreateMap<DeleteProductRequest, DataAccess.Entities.Product>()
            .ForMember(entity => entity.Id, option => option.MapFrom(request => request.ProductId));

            this.CreateMap<UpdateProductRequest, DataAccess.Entities.Product>()
            .ForMember(entity => entity.Id, option => option.MapFrom(request => request.ProductId))
            .ForMember(entity => entity.Name, option => option.MapFrom(request => request.Name))
            .ForMember(entity => entity.Kcal, option => option.MapFrom(request => request.Kcal))
            .ForMember(entity => entity.FatsPerHundredGrams, option => option.MapFrom(request => request.FatsPerHundredGramms))
            .ForMember(entity => entity.CarbsPerHundredGrams, option => option.MapFrom(request => request.CarbsPerHundredGrams))
            .ForMember(entity => entity.ProteinsPerHundredGrams, option => option.MapFrom(request => request.ProteinsPerHundredGrams));
        }
    }
}