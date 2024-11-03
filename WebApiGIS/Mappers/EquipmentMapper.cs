using AutoMapper;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Dtos.Response;
using WebApiGIS.Models;

namespace WebApiGIS.Mappers
{
    public class EquipmentMapper : Profile
    {
        public EquipmentMapper()
        {

            CreateMap<EquipmentType, EquipmentTypeRes>();
            CreateMap<Equipment, EquipmentRes>();

            CreateMap<CreateEquipmentReq, Equipment>();

            CreateMap<UpdateEquipmentReq, Equipment>()
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
