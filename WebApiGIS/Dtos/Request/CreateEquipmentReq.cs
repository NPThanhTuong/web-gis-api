namespace WebApiGIS.Dtos.Request
{
    public class CreateEquipmentReq
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int EquipmentTypeId { get; set; }
        public int RoomId { get; set; }
    }
}
