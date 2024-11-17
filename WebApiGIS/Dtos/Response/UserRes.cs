using WebApiGIS.Enums;

namespace WebApiGIS.Dtos.Response
{
    public class UserRes
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Dob { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public RoleEnum Role { get; set; }
    }
}
