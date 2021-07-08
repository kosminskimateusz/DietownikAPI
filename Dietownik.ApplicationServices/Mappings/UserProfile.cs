using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Users;
using Dietownik.DataAccess.Entities;

namespace Dietownik.ApplicationServices.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<EntityUser, ModelUser>()
            .ForMember(model => model.Id, opt => opt.MapFrom(entity => entity.Id))
            .ForMember(model => model.Username, opt => opt.MapFrom(entity => entity.Username))
            .ForMember(model => model.Email, opt => opt.MapFrom(entity => entity.Email))
            .ForMember(model => model.SpecialUser, opt => opt.MapFrom(entity => entity.SpecialUser));

            this.CreateMap<AddUserRequest, EntityUser>()
            .ForMember(entity => entity.Username, opt => opt.MapFrom(request => request.Username))
            .ForMember(entity => entity.Password, opt => opt.MapFrom(request => request.Password))
            .ForMember(entity => entity.Email, opt => opt.MapFrom(request => request.Email))
            .ForMember(entity => entity.SpecialUser, opt => opt.MapFrom(request => request.SpecialUser));
        }
    }
}