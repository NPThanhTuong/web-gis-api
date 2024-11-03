using AutoMapper;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json.Linq;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Dtos.Response;
using WebApiGIS.Models;

namespace WebApiGIS.Mappers
{
    public class MotelMapper : Profile
    {
        public MotelMapper()
        {
            CreateMap<MotelImage, MotelImageRes>();

            CreateMap<Motel, MotelRes>()
                .ForMember(dest => dest.Geom, opt => opt.MapFrom(src => new GeoJsonWriter().Write(src.Geom)))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.MotelImages));


            CreateMap<CreateMotelReq, Motel>()
                .ForMember(
                    dest => dest.Geom,
                    opt => opt.ConvertUsing(new GeoJsonToGeometryConverter(), src => src.Geom));

            CreateMap<UpdateMotelReq, Motel>()
                .ForMember(
                    dest => dest.Geom,
                    opt => opt.ConvertUsing(new GeoJsonToGeometryConverter(), src => src.Geom))
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

            CreateMap<MotelImageReq, MotelImage>();
        }

        public class GeoJsonToGeometryConverter : IValueConverter<string, Geometry>
        {
            public Geometry Convert(string sourceMember, ResolutionContext context)
            {
                if (!string.IsNullOrEmpty(sourceMember))
                {
                    var reader = new GeoJsonReader();

                    // Parse JSON and extract the `geometry` part of the first feature
                    var featureCollection = JObject.Parse(sourceMember);
                    var geometryToken = featureCollection["features"]?[0]?["geometry"];

                    if (geometryToken != null)
                    {
                        var geometryJson = geometryToken.ToString();
                        return reader.Read<Geometry>(geometryJson);
                    }
                }
                return null;
            }
        }
    }
}
