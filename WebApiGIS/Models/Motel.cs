using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGIS.Models
{
    public class Motel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Geometry Geom { get; set; } = null!;

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        public ICollection<MotelImage> MotelImages { get; set; } = [];

    }
}
