using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using WebApiGIS.Enums;
using WebApiGIS.Models;
using WebApiGIS.Utils;

namespace WebApiGIS.Data
{
    public static class SeedSampleData
    {
        public static ModelBuilder SeedAllData(this ModelBuilder builder)
        {
            builder.SeedEquipmentType()
                .SeedRole()
                .SeedUser()
                .SeedMotel()
                .SeedMotelImage()
                .SeedRoom()
                .SeedEquipment();

            return builder;
        }

        private static ModelBuilder SeedEquipmentType(this ModelBuilder builder)
        {
            builder.Entity<EquipmentType>().HasData(new EquipmentType
            {
                Id = 1,
                Name = "Điện lạnh"
            },
            new EquipmentType
            {
                Id = 2,
                Name = "Gia dụng"
            },
            new EquipmentType
            {
                Id = 3,
                Name = "Khác"
            });

            return builder;
        }

        private static ModelBuilder SeedRole(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = RoleEnum.ADMIN
            },
            new Role
            {
                Id = 2,
                Name = RoleEnum.OWNER
            },
            new Role
            {
                Id = 3,
                Name = RoleEnum.USER
            });

            return builder;
        }

        private static ModelBuilder SeedUser(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
            new User
            {
                Id = ConstConfig.NoUserCode,
                Name = "NoUser",
                Avatar = "N/A",
                Dob = DateOnly.FromDateTime(DateTime.MinValue),
                Email = "N/A",
                PhoneNumber = "N/A",
                RoleId = 1,
                Password = "N/A",
            },
            new User
            {
                Id = 2,
                Name = "Administrator",
                Avatar = "no_avatar.jpg",
                Dob = DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
                Email = "admin@gmail.com",
                PhoneNumber = "0829376780",
                RoleId = 1,
                Password = BCrypt.Net.BCrypt.HashPassword("123456789"),
            },
            new User
            {
                Id = 3,
                Name = "Owner",
                Avatar = "no_avatar.jpg",
                Dob = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)),
                Email = "owner@gmail.com",
                PhoneNumber = "0829876785",
                RoleId = 2,
                Password = BCrypt.Net.BCrypt.HashPassword("123456789"),
            },
            new User
            {
                Id = 4,
                Name = "User",
                Avatar = "no_avatar.jpg",
                Dob = DateOnly.FromDateTime(DateTime.Now.AddYears(-25)),
                Email = "user@gmail.com",
                PhoneNumber = "0829123746",
                RoleId = 3,
                Password = BCrypt.Net.BCrypt.HashPassword("123456789"),
            });

            return builder;
        }

        private static ModelBuilder SeedMotel(this ModelBuilder builder)
        {
            builder.Entity<Motel>().HasData(new Motel
            {
                Id = 1,
                Name = "Nhà Trọ Cô Bảy",
                Description = "Đây là mô tả cho khu nhà trọ của cô Bảy",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.766652, 10.026272) { SRID = 4326 }
            },
            new Motel
            {
                Id = 2,
                Name = "Nhà Trọ Sinh Viên",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = 3,
                Geom = new Point(105.766984, 10.025973) { SRID = 4326 }
            },
            new Motel
            {
                Id = 3,
                Name = "Nhà Trọ Cẩm Tú",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.766292, 10.026623) { SRID = 4326 }
            });

            return builder;
        }

        private static ModelBuilder SeedMotelImage(this ModelBuilder builder)
        {
            builder.Entity<MotelImage>().HasData(new MotelImage
            {
                Id = 1,
                Path = "motel1_image1.jpg",
                MotelId = 1,
            },
            new MotelImage
            {
                Id = 2,
                Path = "motel1_image2.jpg",
                MotelId = 1,
            },
            new MotelImage
            {
                Id = 3,
                Path = "motel1_image3.jpg",
                MotelId = 1,
            },
            new MotelImage
            {
                Id = 4,
                Path = "motel2_image1.jpg",
                MotelId = 2,
            },
            new MotelImage
            {
                Id = 5,
                Path = "motel2_image2.jpg",
                MotelId = 2,
            },
            new MotelImage
            {
                Id = 6,
                Path = "motel2_image3.jpg",
                MotelId = 2,
            }, new MotelImage
            {
                Id = 7,
                Path = "motel3_image1.jpg",
                MotelId = 3,
            },
            new MotelImage
            {
                Id = 8,
                Path = "motel3_image2.jpg",
                MotelId = 3,
            },
            new MotelImage
            {
                Id = 9,
                Path = "motel3_image3.jpg",
                MotelId = 3,
            });

            return builder;
        }

        private static ModelBuilder SeedRoom(this ModelBuilder builder)
        {
            builder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Price = 1200,
                    Capability = 2,
                    Description = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = true,
                    MotelId = 1,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.7662, 10.0260),
                        new Coordinate(105.7665, 10.0260),
                        new Coordinate(105.7665, 10.0263),
                        new Coordinate(105.7662, 10.0263),
                        new Coordinate(105.7662, 10.0260)
                    ]))
                    { SRID = 4326 }
                },
                new Room
                {
                    Id = 2,
                    Price = 1200,
                    Capability = 2,
                    Description = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = true,
                    MotelId = 1,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.7667, 10.0260),
                        new Coordinate(105.7670, 10.0260),
                        new Coordinate(105.7670, 10.0263),
                        new Coordinate(105.7667, 10.0263),
                        new Coordinate(105.7667, 10.0260)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 3,
                    Price = 1300,
                    Capability = 2,
                    Description = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = true,
                    MotelId = 1,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.7672, 10.0261),
                        new Coordinate(105.7675, 10.0261),
                        new Coordinate(105.7675, 10.0264),
                        new Coordinate(105.7672, 10.0264),
                        new Coordinate(105.7672, 10.0261)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 4,
                    Price = 1500,
                    Capability = 3,
                    Description = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = true,
                    MotelId = 2,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.7668, 10.0258),
                        new Coordinate(105.7670, 10.0258),
                        new Coordinate(105.7670, 10.0260),
                        new Coordinate(105.7668, 10.0260),
                        new Coordinate(105.7668, 10.0258)
                    ]))
                    { SRID = 4326 }
                },
                new Room
                {
                    Id = 5,
                    Price = 1500,
                    Capability = 3,
                    Description = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = true,
                    MotelId = 2,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.7666, 10.0257),
                        new Coordinate(105.7669, 10.0257),
                        new Coordinate(105.7669, 10.0259),
                        new Coordinate(105.7666, 10.0259),
                        new Coordinate(105.7666, 10.0257)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 6,
                    Price = 1500,
                    Capability = 3,
                    Description = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = true,
                    MotelId = 2,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.7671, 10.0259),
                        new Coordinate(105.7673, 10.0259),
                        new Coordinate(105.7673, 10.0261),
                        new Coordinate(105.7671, 10.0261),
                        new Coordinate(105.7671, 10.0259)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 7,
                    Price = 800,
                    Capability = 1,
                    Description = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 3,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.7661, 10.0265),
                        new Coordinate(105.7663, 10.0265),
                        new Coordinate(105.7663, 10.0267),
                        new Coordinate(105.7661, 10.0267),
                        new Coordinate(105.7661, 10.0265)
                    ]))
                    { SRID = 4326 }
                },
                new Room
                {
                    Id = 8,
                    Price = 800,
                    Capability = 1,
                    Description = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 3,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.7663, 10.0266),
                        new Coordinate(105.7665, 10.0266),
                        new Coordinate(105.7665, 10.0268),
                        new Coordinate(105.7663, 10.0268),
                        new Coordinate(105.7663, 10.0266)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 9,
                    Price = 800,
                    Capability = 1,
                    Description = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 3,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.7662, 10.0268),
                        new Coordinate(105.7664, 10.0268),
                        new Coordinate(105.7664, 10.0270),
                        new Coordinate(105.7662, 10.0270),
                        new Coordinate(105.7662, 10.0268)
                    ]))
                    { SRID = 4326 },
                }
            );

            return builder;
        }

        private static ModelBuilder SeedEquipment(this ModelBuilder builder)
        {
            builder.Entity<Equipment>().HasData(new Equipment
            {
                Id = 1,
                Name = "Tủ lạnh",
                Description = "Đây là mô tả cho tủ lạnh của nhà trọ",
                EquipmentTypeId = 1,
                RoomId = 1,
            },
            new Equipment
            {
                Id = 2,
                Name = "Bàn",
                Description = "Đây là mô tả cho cái bàn của nhà trọ",
                EquipmentTypeId = 3,
                RoomId = 2,
            });

            return builder;
        }
    }
}