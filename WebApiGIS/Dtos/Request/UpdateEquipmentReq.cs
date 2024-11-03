namespace WebApiGIS.Dtos.Request
{
    public class UpdateEquipmentReq
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int? EquipmentTypeId { get; set; }
        public int? RoomId { get; set; }
    }
}
