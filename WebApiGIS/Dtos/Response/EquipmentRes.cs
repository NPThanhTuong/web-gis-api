namespace WebApiGIS.Dtos.Response
{
    public class EquipmentRes
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public EquipmentTypeRes EquipmentType { get; set; } = null!;
    }
}
