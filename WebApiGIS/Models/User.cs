using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGIS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly? Dob { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; } = null!;

        public ICollection<Motel> Motels { get; set; } = [];
    }
}
