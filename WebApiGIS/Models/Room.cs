using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGIS.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Capability { get; set; }
        public bool IsMezzanine { get; set; }
        public bool IsAvaileble { get; set; }
        public string Descripption { get; set; } = string.Empty;
        public Geometry Geom { get; set; } = null!;

        public int MotelId { get; set; }
        [ForeignKey(nameof(MotelId))]
        public Motel Motel { get; set; } = null!;

        public ICollection<Equipment> Equipments { get; set; } = [];
    }
}
