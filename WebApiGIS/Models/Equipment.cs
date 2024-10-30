using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGIS.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int EquipmentTypeId { get; set; }
        [ForeignKey(nameof(EquipmentTypeId))]
        public EquipmentType EquipmentType { get; set; } = null!;

        public int RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; } = null!;
    }
}
