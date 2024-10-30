using Microsoft.EntityFrameworkCore;
using WebApiGIS.Models;

namespace WebApiGIS.Data
{
    public class WebGisDbContext : DbContext
    {
        public WebGisDbContext(DbContextOptions<WebGisDbContext> options)
         : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Motel> Motels { get; set; }
        public DbSet<MotelImage> MotelImages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
              .Property(o => o.Name)
              .HasConversion<string>();

            modelBuilder.SeedAllData();
        }
    }
}
