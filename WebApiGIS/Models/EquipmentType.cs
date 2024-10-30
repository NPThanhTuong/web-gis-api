namespace WebApiGIS.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Equipment> Equipments { get; set; } = [];
    }
}
