using AutoMapper;
using NetTopologySuite.IO;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Dtos.Response;
using WebApiGIS.Models;
using static WebApiGIS.Mappers.MotelMapper;

namespace WebApiGIS.Mappers
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<Room, RoomRes>()
                .ForMember(dest => dest.Geom, opt => opt.MapFrom(src => new GeoJsonWriter().Write(src.Geom)));

            CreateMap<CreateRoomReq, Room>()
                .ForMember(
                    dest => dest.Geom,
                    opt => opt.ConvertUsing(new GeoJsonToGeometryConverter(), src => src.Geom));

            CreateMap<UpdateRoomReq, Room>()
                .ForMember(
                    dest => dest.Geom,
                    opt => opt.ConvertUsing(new GeoJsonToGeometryConverter(), src => src.Geom))
                 .ForMember(dest => dest.IsMezzanine, opt => opt.Ignore())
                 .ForMember(dest => dest.IsAvailable, opt => opt.Ignore())
                .ForAllMembers(opts => opts
                    .Condition((src, dest, srcMember) =>
                    {
                        // Ignore null value
                        if (srcMember is null) return false;

                        // Ignore empty string value
                        if (srcMember is string str) return !string.IsNullOrWhiteSpace(str);

                        // Ignore default int value
                        if (srcMember is int i) return i != default;

                        return true;
                    }));
        }
    }
}
