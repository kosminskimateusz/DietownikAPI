using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Products;
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
            .ForMember(model => model.Kcal, option => option.MapFrom(entity => entity.Kcal))
            .ForMember(model => model.Fats, option => option.MapFrom(entity => entity.Fats))
            .ForMember(model => model.Carbs, option => option.MapFrom(entity => entity.Carbs))
            .ForMember(model => model.Proteins, option => option.MapFrom(entity => entity.Proteins));

            this.CreateMap<AddProductRequest, DataAccess.Entities.Product>()
            .ForMember(entity => entity.Name, option => option.MapFrom(request => request.Name))
            .ForMember(entity => entity.Kcal, option => option.MapFrom(request => request.Kcal))
            .ForMember(entity => entity.Fats, option => option.MapFrom(request => request.Fats))
            .ForMember(entity => entity.Carbs, option => option.MapFrom(request => request.Carbs))
            .ForMember(entity => entity.Proteins, option => option.MapFrom(request => request.Proteins));

            this.CreateMap<DeleteProductRequest, DataAccess.Entities.Product>()
            .ForMember(entity => entity.Id, option => option.MapFrom(request => request.ProductId));

            this.CreateMap<UpdateProductRequest, DataAccess.Entities.Product>()
            .ForMember(entity => entity.Id, option => option.MapFrom(request => request.productId))
            .ForMember(entity => entity.Name, option => option.MapFrom(request => request.Name))
            .ForMember(entity => entity.Kcal, option => option.MapFrom(request => request.Kcal))
            .ForMember(entity => entity.Fats, option => option.MapFrom(request => request.Fats))
            .ForMember(entity => entity.Carbs, option => option.MapFrom(request => request.Carbs))
            .ForMember(entity => entity.Proteins, option => option.MapFrom(request => request.Proteins));
        }
    }
}