using AutoMapper;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Dtos.Response;
using WebApiGIS.Models;
using WebApiGIS.Utils;

namespace WebApiGIS.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserRes>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<RegisterReq, User>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => ConstConfig.AdminRoleCode))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => "no-avatar.jpg"))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));
        }
    }
}
