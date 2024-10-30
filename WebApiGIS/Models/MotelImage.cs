using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGIS.Models
{
    [Index(nameof(Path), IsUnique = true)]
    public class MotelImage
    {
        public int Id { get; set; }
        public string Path { get; set; } = string.Empty;

        public int MotelId { get; set; }
        [ForeignKey(nameof(MotelId))]
        public Motel Motel { get; set; } = null!;
    }
}
