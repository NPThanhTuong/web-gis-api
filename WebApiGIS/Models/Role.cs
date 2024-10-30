using WebApiGIS.Enums;

namespace WebApiGIS.Models
{
    public class Role
    {
        public int Id { get; set; }
        public RoleEnum Name { get; set; } = RoleEnum.USER;

        public ICollection<User> Users { get; set; } = [];
    }
}
