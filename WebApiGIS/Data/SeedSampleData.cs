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
                Geom = new Point(105.76651147, 10.02616132) { SRID = 4326 }
            },
            new Motel
            {
                Id = 2,
                Name = "Nhà Trọ Sinh Viên",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = 3,
                Geom = new Point(105.76699673, 10.02602386) { SRID = 4326 }
            },
            new Motel
            {
                Id = 3,
                Name = "Nhà Trọ Cẩm Tú",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76631803, 10.02661963) { SRID = 4326 }
            },
            new Motel
            {
                Id = 4,
                Name = "Nhà Trọ 51D5",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76543647, 10.02658606) { SRID = 4326 }
            },
            new Motel
            {
                Id = 5,
                Name = "Nhà Trọ Hồng Mai",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76532650, 10.02651541) { SRID = 4326 }
            },
            new Motel
            {
                Id = 6,
                Name = "Nhà Trọ Phú",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76708326, 10.02615788) { SRID = 4326 }
            },
            new Motel
            {
                Id = 7,
                Name = "Nhà Trọ Cô Huyền",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76793433, 10.02542560) { SRID = 4326 }
            },
            new Motel
            {
                Id = 8,
                Name = "Nhà Trọ 162/1",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76906116, 10.02483667) { SRID = 4326 }
            },
            new Motel
            {
                Id = 9,
                Name = "Nhà Trọ Lâm Thành",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76447833, 10.02523783) { SRID = 4326 }
            },
            new Motel
            {
                Id = 10,
                Name = "Nhà Trọ Ngọc Thắm",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76482417, 10.02520947) { SRID = 4326 }
            },
            new Motel
            {
                Id = 11,
                Name = "Nhà Trọ Anh Hà",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76466538, 10.02560840) { SRID = 4326 }
            },
            new Motel
            {
                Id = 12,
                Name = "Nhà Trọ Thiên Thanh",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76286885, 10.02724987) { SRID = 4326 }
            },
            new Motel
            {
                Id = 13,
                Name = "Nhà Trọ Thùy Dung",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76236970, 10.02723936) { SRID = 4326 }
            },
            new Motel
            {
                Id = 14,
                Name = "Nhà Trọ Hồ Bún Xáng",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76207943, 10.02771621) { SRID = 4326 }
            },
            new Motel
            {
                Id = 15,
                Name = "Nhà Trọ Bác Nhựt",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76468957, 10.02371891) { SRID = 4326 }
            },
            new Motel
            {
                Id = 16,
                Name = "Nhà Trọ 228",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76553482, 10.02335208) { SRID = 4326 }
            },
            new Motel
            {
                Id = 17,
                Name = "Nhà Trọ Bác Ba Lai",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76464028, 10.02421123) { SRID = 4326 }
            },
            new Motel
            {
                Id = 18,
                Name = "Nhà Trọ 35",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76869363, 10.02310219) { SRID = 4326 }
            },
            new Motel
            {
                Id = 19,
                Name = "Nhà Trọ 172E",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76797270, 10.02285241) { SRID = 4326 }
            },
            new Motel
            {
                Id = 20,
                Name = "Nhà Trọ Tôn Nữ Minh Phương",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76868212, 10.02458309) { SRID = 4326 }
            },
            new Motel
            {
                Id = 21,
                Name = "Nhà Trọ Bảo Ngọc",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.77063478, 10.02743079) { SRID = 4326 }
            },
            new Motel
            {
                Id = 22,
                Name = "Nhà Trọ Phú Quý",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.77157813, 10.02777570) { SRID = 4326 }
            },
            new Motel
            {
                Id = 23,
                Name = "Nhà Trọ Huỳnh Liên",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.77178532, 10.02760614) { SRID = 4326 }
            },
            new Motel
            {
                Id = 24,
                Name = "Nhà Trọ Minh Thông",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.77204347, 10.02757789) { SRID = 4326 }
            },
            new Motel
            {
                Id = 25,
                Name = "Nhà Trọ Yến Trang",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.77180066, 10.02744434) { SRID = 4326 }
            },
            new Motel
            {
                Id = 26,
                Name = "Nhà Trọ Hồng Ngọc",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.77149300, 10.02751050) { SRID = 4326 }
            },
            new Motel
            {
                Id = 27,
                Name = "Nhà Trọ D20",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.77421970, 10.02773533) { SRID = 4326 }
            },
            new Motel
            {
                Id = 28,
                Name = "Nhà Trọ Nguyễn Thị Thu Hiền",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76382451, 10.02059803) { SRID = 4326 }
            },
            new Motel
            {
                Id = 29,
                Name = "Nhà Trọ Số 5",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76312068, 10.02136834) { SRID = 4326 }
            },
            new Motel
            {
                Id = 30,
                Name = "Nhà Trọ Gia Hân",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.76040846, 10.02226578) { SRID = 4326 }
            },
            new Motel
            {
                Id = 31,
                Name = "Nhà Trọ Lý Mỹ Lan",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75794523, 10.02580295) { SRID = 4326 }
            },
            new Motel
            {
                Id = 32,
                Name = "Nhà Trọ Nguyễn Văn Hai",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75666203, 10.02686793) { SRID = 4326 }
            },
            new Motel
            {
                Id = 33,
                Name = "Nhà Trọ Minh Phát",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75654512, 10.02694981) { SRID = 4326 }
            },
            new Motel
            {
                Id = 34,
                Name = "Nhà Trọ Thanh Vinh",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75554082, 10.02682668) { SRID = 4326 }
            },
            new Motel
            {
                Id = 35,
                Name = "Nhà Trọ Nguyễn Thị Hải",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75547299, 10.02719749) { SRID = 4326 }
            },
            new Motel
            {
                Id = 36,
                Name = "Nhà Trọ Bình Khánh",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75558096, 10.02762116) { SRID = 4326 }
            },
            new Motel
            {
                Id = 37,
                Name = "Nhà Trọ Nguyễn Thị Hiền",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75515522, 10.02793749) { SRID = 4326 }
            },
            new Motel
            {
                Id = 38,
                Name = "Nhà Trọ Hoà Thảo",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75496540, 10.02721379) { SRID = 4326 }
            },
            new Motel
            {
                Id = 39,
                Name = "Nhà Trọ Hai Thìn 2",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75444251, 10.02713880) { SRID = 4326 }
            },
            new Motel
            {
                Id = 40,
                Name = "Nhà Trọ Minh Tiến",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75433058, 10.02669408) { SRID = 4326 }
            },
            new Motel
            {
                Id = 41,
                Name = "Nhà Trọ Hai Lừng",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75411332, 10.02663465) { SRID = 4326 }
            },
            new Motel
            {
                Id = 42,
                Name = "Nhà Trọ Tài Lộc",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75405456, 10.02684665) { SRID = 4326 }
            },
            new Motel
            {
                Id = 43,
                Name = "Nhà Trọ Ngân An",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75284905, 10.02620235) { SRID = 4326 }
            },
            new Motel
            {
                Id = 44,
                Name = "Nhà Trọ 333J",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75230807, 10.02615985) { SRID = 4326 }
            },
            new Motel
            {
                Id = 45,
                Name = "Nhà Trọ Thành Phát",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75330840, 10.02519691) { SRID = 4326 }
            },
            new Motel
            {
                Id = 46,
                Name = "Nhà Trọ Dì Tám",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75277908, 10.02527699) { SRID = 4326 }
            },
            new Motel
            {
                Id = 47,
                Name = "Nhà Trọ Gia Du",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75325866, 10.02575848) { SRID = 4326 }
            },
            new Motel
            {
                Id = 48,
                Name = "Nhà Trọ Thế Vinh",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75167063, 10.02558346) { SRID = 4326 }
            },
            new Motel
            {
                Id = 49,
                Name = "Nhà Trọ Trí Ngân",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75779927, 10.02157943) { SRID = 4326 }
            },
            new Motel
            {
                Id = 50,
                Name = "Nhà Trọ Phạm Dung",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75811629, 10.02162671) { SRID = 4326 }
            },
            new Motel
            {
                Id = 51,
                Name = "Nhà Trọ Triều Tân",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75854999, 10.02166691) { SRID = 4326 }
            },
            new Motel
            {
                Id = 52,
                Name = "Nhà Trọ Trương Tuấn",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75958660, 10.02184323) { SRID = 4326 }
            },
            new Motel
            {
                Id = 53,
                Name = "Nhà Trọ Hưng Lợi",
                Description = "Đây là mô tả cho khu nhà trọ sinh viên",
                UserId = ConstConfig.NoUserCode,
                Geom = new Point(105.75969657, 10.02174418) { SRID = 4326 }
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
                        new Coordinate(105.76650962, 10.02617579),
                        new Coordinate(105.76654717, 10.02621871),
                        new Coordinate(105.76657936, 10.02618767),
                        new Coordinate(105.76654046, 10.02615003),
                        new Coordinate(105.76650962, 10.02617579)
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
                        new Coordinate(105.76657802, 10.02624776),
                        new Coordinate(105.76661959, 10.02628474),
                        new Coordinate(105.76666385, 10.02624446),
                        new Coordinate(105.76663099, 10.02619890),
                        new Coordinate(105.76657802, 10.02624776)
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
                        new Coordinate(105.76667390, 10.02634350),
                        new Coordinate(105.76672822, 10.02629530),
                        new Coordinate(105.76669469, 10.02626823),
                        new Coordinate(105.76664440, 10.02631379),
                        new Coordinate(105.76667390, 10.02634350)
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
                        new Coordinate(105.76699595, 10.02602620),
                        new Coordinate(105.76702613, 10.02599583),
                        new Coordinate(105.76700802, 10.02597800),
                        new Coordinate(105.76698120, 10.02601300),
                        new Coordinate(105.76699595, 10.02602620)
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
                        new Coordinate(105.76696108, 10.02599319),
                        new Coordinate(105.76699796, 10.02596677),
                        new Coordinate(105.76696779, 10.02593904),
                        new Coordinate(105.76693024, 10.02596942),
                        new Coordinate(105.76696108, 10.02599319)
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
                        new Coordinate(105.76691481, 10.02595423),
                        new Coordinate(105.76694164, 10.02591725),
                        new Coordinate(105.76691481, 10.02589678),
                        new Coordinate(105.76688732, 10.02592848),
                        new Coordinate(105.76691481, 10.02595423)
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
                        new Coordinate(105.76630100, 10.02666573),
                        new Coordinate(105.76632849, 10.02663866),
                        new Coordinate(105.76630837, 10.02661423),
                        new Coordinate(105.76628021, 10.02664460),
                        new Coordinate(105.76630100, 10.02666573)
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
                        new Coordinate(105.76625339, 10.02661885),
                        new Coordinate(105.76628625, 10.02659508),
                        new Coordinate(105.76625607, 10.02656603),
                        new Coordinate(105.76621182, 10.02657989),
                        new Coordinate(105.76625339, 10.02661885)
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
                        new Coordinate(105.76634593, 10.02662083),
                        new Coordinate(105.76637677, 10.02660036),
                        new Coordinate(105.76634861, 10.02657263),
                        new Coordinate(105.76630837, 10.02658187),
                        new Coordinate(105.76634593, 10.02662083)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 10,
                    Price = 600,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 4,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76545436, 10.02660629),
                        new Coordinate(105.76542083, 10.02656998),
                        new Coordinate(105.76539334, 10.02659441),
                        new Coordinate(105.76543223, 10.02662610),
                        new Coordinate(105.76545436, 10.02660629)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 11,
                    Price = 600,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 4,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76536786, 10.02662214),
                        new Coordinate(105.76540139, 10.02665780),
                        new Coordinate(105.76533769, 10.02664987),
                        new Coordinate(105.76537524, 10.02668553),
                        new Coordinate(105.76536786, 10.02662214)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 12,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 5,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76532109, 10.02651410),
                        new Coordinate(105.76535730, 10.02655174),
                        new Coordinate(105.76532914, 10.02656627),
                        new Coordinate(105.76530366, 10.02653193),
                        new Coordinate(105.76532109, 10.02651410)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 13,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 5,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76535127, 10.02660654),
                        new Coordinate(105.76533115, 10.02658872),
                        new Coordinate(105.76530433, 10.02661975),
                        new Coordinate(105.76532311, 10.02663362),
                        new Coordinate(105.76535127, 10.02660654)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 14,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 5,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76527281, 10.02663494),
                        new Coordinate(105.76528287, 10.02659994),
                        new Coordinate(105.76527416, 10.02656561),
                        new Coordinate(105.76523996, 10.02659994),
                        new Coordinate(105.76527281, 10.02663494)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 15,
                    Price = 700,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 6,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76707040, 10.02611043),
                        new Coordinate(105.76709320, 10.02614146),
                        new Coordinate(105.76715086, 10.02611109),
                        new Coordinate(105.76711801, 10.02607807),
                        new Coordinate(105.76707040, 10.02611043)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 16,
                    Price = 700,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 6,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76706973, 10.02616589),
                        new Coordinate(105.76712136, 10.02615731),
                        new Coordinate(105.76715623, 10.02620683),
                        new Coordinate(105.76712002, 10.02622202),
                        new Coordinate(105.76706973, 10.02616589)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 17,
                    Price = 700,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 6,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76721188, 10.02633559),
                        new Coordinate(105.76727492, 10.02628277),
                        new Coordinate(105.76725614, 10.02625305),
                        new Coordinate(105.76718104, 10.02629531),
                        new Coordinate(105.76721188, 10.02633559)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 18,
                    Price = 1400,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 7,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76795453, 10.02539817),
                        new Coordinate(105.76797732, 10.02542195),
                        new Coordinate(105.76790356, 10.02548269),
                        new Coordinate(105.76788278, 10.02546090),
                        new Coordinate(105.76795453, 10.02539817)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 19,
                    Price = 1400,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 7,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76779829, 10.02557844),
                        new Coordinate(105.76786400, 10.02551901),
                        new Coordinate(105.76783383, 10.02546883),
                        new Coordinate(105.76779628, 10.02550052),
                        new Coordinate(105.76779829, 10.02557844)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 20,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 8,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76908958, 10.02480883),
                        new Coordinate(105.76905203, 10.02477647),
                        new Coordinate(105.76903125, 10.02480223),
                        new Coordinate(105.76906813, 10.02483590),
                        new Coordinate(105.76908958, 10.02480883)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 21,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 8,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76901180, 10.02490193),
                        new Coordinate(105.76904466, 10.02486166),
                        new Coordinate(105.76900442, 10.02483260),
                        new Coordinate(105.76897626, 10.02487354),
                        new Coordinate(105.76901180, 10.02490193)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 22,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 9,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76445727, 10.02526069),
                        new Coordinate(105.76444386, 10.02522966),
                        new Coordinate(105.76450690, 10.02519400),
                        new Coordinate(105.76454378, 10.02520523),
                        new Coordinate(105.76445727, 10.02526069)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 23,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 10,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76481334, 10.02528512),
                        new Coordinate(105.76485089, 10.02526135),
                        new Coordinate(105.76481401, 10.02521117),
                        new Coordinate(105.76478249, 10.02523230),
                        new Coordinate(105.76481334, 10.02528512)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 24,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 10,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76487905, 10.02524683),
                        new Coordinate(105.76492465, 10.02521381),
                        new Coordinate(105.76489246, 10.02516627),
                        new Coordinate(105.76484754, 10.02519004),
                        new Coordinate(105.76487905, 10.02524683)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 25,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 10,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76496622, 10.02519004),
                        new Coordinate(105.76501450, 10.02516099),
                        new Coordinate(105.76499372, 10.02510552),
                        new Coordinate(105.76491929, 10.02514910),
                        new Coordinate(105.76496622, 10.02519004)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 26,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 10,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76509631, 10.02511542),
                        new Coordinate(105.76507016, 10.02505732),
                        new Coordinate(105.76503730, 10.02507911),
                        new Coordinate(105.76505809, 10.02513853),
                        new Coordinate(105.76509631, 10.02511542)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 27,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 11,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76466495, 10.02560735),
                        new Coordinate(105.76471055, 10.02558358),
                        new Coordinate(105.76469312, 10.02554264),
                        new Coordinate(105.76464484, 10.02557169),
                        new Coordinate(105.76466495, 10.02560735)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 28,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 11,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76483594, 10.02551094),
                        new Coordinate(105.76481315, 10.02547463),
                        new Coordinate(105.76477962, 10.02553934),
                        new Coordinate(105.76474810, 10.02550962),
                        new Coordinate(105.76483594, 10.02551094)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 29,
                    Price = 500,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 12,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76296054, 10.02727302),
                        new Coordinate(105.76294713, 10.02723142),
                        new Coordinate(105.76289013, 10.02728887),
                        new Coordinate(105.76287538, 10.02724397),
                        new Coordinate(105.76296054, 10.02727302)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 30,
                    Price = 500,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 12,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76285996, 10.02729613),
                        new Coordinate(105.76284923, 10.02725321),
                        new Coordinate(105.76276541, 10.02727368),
                        new Coordinate(105.76277547, 10.02731594),
                        new Coordinate(105.76285996, 10.02729613)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 31,
                    Price = 1300,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 13,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76234687, 10.02727035),
                        new Coordinate(105.76234285, 10.02723865),
                        new Coordinate(105.76222684, 10.02725780),
                        new Coordinate(105.76220739, 10.02729412),
                        new Coordinate(105.76234687, 10.02727035)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 32,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 14,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76203919, 10.02774690),
                        new Coordinate(105.76211564, 10.02775020),
                        new Coordinate(105.76211631, 10.02791198),
                        new Coordinate(105.76204724, 10.02790405),
                        new Coordinate(105.76203919, 10.02774690)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 33,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 15,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76468724, 10.02371374),
                        new Coordinate(105.76474156, 10.02368733),
                        new Coordinate(105.76473150, 10.02366289),
                        new Coordinate(105.76467786, 10.02368997),
                        new Coordinate(105.76468724, 10.02371374)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 34,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 16,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76557860, 10.02334896),
                        new Coordinate(105.76554910, 10.02331463),
                        new Coordinate(105.76552026, 10.02334962),
                        new Coordinate(105.76554105, 10.02338066),
                        new Coordinate(105.76557860, 10.02334896)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 35,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 16,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76550484, 10.02340509),
                        new Coordinate(105.76547198, 10.02336283),
                        new Coordinate(105.76541834, 10.02341301),
                        new Coordinate(105.76545254, 10.02345197),
                        new Coordinate(105.76550484, 10.02340509)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 36,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 16,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76536000, 10.02353583),
                        new Coordinate(105.76540157, 10.02349819),
                        new Coordinate(105.76536268, 10.02346320),
                        new Coordinate(105.76532379, 10.02349555),
                        new Coordinate(105.76536000, 10.02353583)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 37,
                    Price = 1400,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 17,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76463202, 10.02421029),
                        new Coordinate(105.76469975, 10.02417463),
                        new Coordinate(105.76468768, 10.02414029),
                        new Coordinate(105.76461660, 10.02417661),
                        new Coordinate(105.76463202, 10.02421029)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 38,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 18,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76864041, 10.02312304),
                        new Coordinate(105.76872624, 10.02320624),
                        new Coordinate(105.76877184, 10.02317389),
                        new Coordinate(105.76867662, 10.02308805),
                        new Coordinate(105.76864041, 10.02312304)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 39,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 18,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76888181, 10.02334821),
                        new Coordinate(105.76891131, 10.02330133),
                        new Coordinate(105.76884426, 10.02324058),
                        new Coordinate(105.76880335, 10.02327095),
                        new Coordinate(105.76888181, 10.02334821)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 40,
                    Price = 600,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 19,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76792659, 10.02284306),
                        new Coordinate(105.76799767, 10.02291702),
                        new Coordinate(105.76803790, 10.02289721),
                        new Coordinate(105.76796347, 10.02281797),
                        new Coordinate(105.76792659, 10.02284306)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 41,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 20,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76860282, 10.02456365),
                        new Coordinate(105.76865244, 10.02460327),
                        new Coordinate(105.76868865, 10.02455440),
                        new Coordinate(105.76864171, 10.02452007),
                        new Coordinate(105.76860282, 10.02456365)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 42,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 20,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76868731, 10.02463034),
                        new Coordinate(105.76874230, 10.02467326),
                        new Coordinate(105.76877046, 10.02462572),
                        new Coordinate(105.76871682, 10.02458082),
                        new Coordinate(105.76868731, 10.02463034)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 43,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 20,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76885696, 10.02476702),
                        new Coordinate(105.76889250, 10.02472278),
                        new Coordinate(105.76883081, 10.02467326),
                        new Coordinate(105.76878387, 10.02471222),
                        new Coordinate(105.76885696, 10.02476702)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 44,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 21,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77063785, 10.02741815),
                        new Coordinate(105.77062242, 10.02738249),
                        new Coordinate(105.77067070, 10.02735872),
                        new Coordinate(105.77067473, 10.02739372),
                        new Coordinate(105.77063785, 10.02741815)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 45,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 22,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77153235, 10.02778721),
                        new Coordinate(105.77152765, 10.02776476),
                        new Coordinate(105.77158934, 10.02775815),
                        new Coordinate(105.77160208, 10.02777598),
                        new Coordinate(105.77153235, 10.02778721)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 46,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 23,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77171474, 10.02759638),
                        new Coordinate(105.77172278, 10.02763005),
                        new Coordinate(105.77175631, 10.02761487),
                        new Coordinate(105.77174692, 10.02758779),
                        new Coordinate(105.77171474, 10.02759638)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 47,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 23,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77182739, 10.02756930),
                        new Coordinate(105.77179990, 10.02757657),
                        new Coordinate(105.77180995, 10.02763401),
                        new Coordinate(105.77184281, 10.02763467),
                        new Coordinate(105.77182739, 10.02756930)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 48,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 23,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77173686, 10.02765316),
                        new Coordinate(105.77178447, 10.02764194),
                        new Coordinate(105.77179453, 10.02768354),
                        new Coordinate(105.77174558, 10.02770203),
                        new Coordinate(105.77173686, 10.02765316)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 49,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 24,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77205323, 10.02761794),
                        new Coordinate(105.77203780, 10.02755521),
                        new Coordinate(105.77200092, 10.02756247),
                        new Coordinate(105.77202439, 10.02762388),
                        new Coordinate(105.77205323, 10.02761794)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 50,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 24,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77197745, 10.02757040),
                        new Coordinate(105.77199087, 10.02763114),
                        new Coordinate(105.77193655, 10.02764633),
                        new Coordinate(105.77191576, 10.02758624),
                        new Coordinate(105.77197745, 10.02757040)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 51,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 24,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77187486, 10.02766152),
                        new Coordinate(105.77185676, 10.02759945),
                        new Coordinate(105.77188559, 10.02759285),
                        new Coordinate(105.77190436, 10.02765227),
                        new Coordinate(105.77187486, 10.02766152)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 52,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 25,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77176894, 10.02749898),
                        new Coordinate(105.77184740, 10.02748709),
                        new Coordinate(105.77184472, 10.02746332),
                        new Coordinate(105.77176492, 10.02747586),
                        new Coordinate(105.77176894, 10.02749898)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 53,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 25,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77175821, 10.02745077),
                        new Coordinate(105.77184002, 10.02744087),
                        new Coordinate(105.77183332, 10.02740389),
                        new Coordinate(105.77175486, 10.02741314),
                        new Coordinate(105.77175821, 10.02745077)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 54,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 25,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77174950, 10.02738738),
                        new Coordinate(105.77182594, 10.02737682),
                        new Coordinate(105.77182058, 10.02732730),
                        new Coordinate(105.77174279, 10.02733852),
                        new Coordinate(105.77174950, 10.02738738)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 55,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 25,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77173542, 10.02731013),
                        new Coordinate(105.77181320, 10.02730088),
                        new Coordinate(105.77180784, 10.02726391),
                        new Coordinate(105.77173005, 10.02727381),
                        new Coordinate(105.77173542, 10.02731013)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 56,
                    Price = 700,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 26,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77149862, 10.02756959),
                        new Coordinate(105.77153483, 10.02756497),
                        new Coordinate(105.77152544, 10.02751214),
                        new Coordinate(105.77149058, 10.02751742),
                        new Coordinate(105.77149862, 10.02756959)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 57,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 27,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77419210, 10.02774824),
                        new Coordinate(105.77423233, 10.02773768),
                        new Coordinate(105.77421758, 10.02767627),
                        new Coordinate(105.77417802, 10.02769212),
                        new Coordinate(105.77419210, 10.02774824)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 58,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 27,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.77416461, 10.02764127),
                        new Coordinate(105.77420283, 10.02762939),
                        new Coordinate(105.77418942, 10.02757326),
                        new Coordinate(105.77414986, 10.02758449),
                        new Coordinate(105.77416461, 10.02764127)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 59,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 28,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76380510, 10.02063423),
                        new Coordinate(105.76378767, 10.02060122),
                        new Coordinate(105.76384064, 10.02056688),
                        new Coordinate(105.76386411, 10.02059792),
                        new Coordinate(105.76380510, 10.02063423)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 60,
                    Price = 1500,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 29,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76318354, 10.02143109),
                        new Coordinate(105.76311715, 10.02136704),
                        new Coordinate(105.76305211, 10.02143373),
                        new Coordinate(105.76312319, 10.02148523),
                        new Coordinate(105.76318354, 10.02143109)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 61,
                    Price = 1500,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 29,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76302864, 10.02157966),
                        new Coordinate(105.76306552, 10.02154268),
                        new Coordinate(105.76300450, 10.02147797),
                        new Coordinate(105.76296427, 10.02151627),
                        new Coordinate(105.76302864, 10.02157966)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 62,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 30,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76034769, 10.02228348),
                        new Coordinate(105.76040334, 10.02224254),
                        new Coordinate(105.76044089, 10.02229933),
                        new Coordinate(105.76038256, 10.02232971),
                        new Coordinate(105.76034769, 10.02228348)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 63,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 30,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.76044425, 10.02241687),
                        new Coordinate(105.76049789, 10.02237791),
                        new Coordinate(105.76047241, 10.02233763),
                        new Coordinate(105.76041340, 10.02237395),
                        new Coordinate(105.76044425, 10.02241687)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 64,
                    Price = 600,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 31,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75793702, 10.02584708),
                        new Coordinate(105.75797256, 10.02583783),
                        new Coordinate(105.75793300, 10.02578765),
                        new Coordinate(105.75790752, 10.02580349),
                        new Coordinate(105.75793702, 10.02584708)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 65,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 32,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75661860, 10.02691791),
                        new Coordinate(105.75666486, 10.02686046),
                        new Coordinate(105.75663938, 10.02684263),
                        new Coordinate(105.75659982, 10.02690074),
                        new Coordinate(105.75661860, 10.02691791)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 66,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 32,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75657769, 10.02688159),
                        new Coordinate(105.75662061, 10.02683009),
                        new Coordinate(105.75658306, 10.02679575),
                        new Coordinate(105.75653545, 10.02684461),
                        new Coordinate(105.75657769, 10.02688159)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 67,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 32,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75651198, 10.02682612),
                        new Coordinate(105.75655892, 10.02677264),
                        new Coordinate(105.75653612, 10.02675745),
                        new Coordinate(105.75649052, 10.02680830),
                        new Coordinate(105.75651198, 10.02682612)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 68,
                    Price = 400,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 33,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75653677, 10.02697599),
                        new Coordinate(105.75656359, 10.02693241),
                        new Coordinate(105.75653945, 10.02691657),
                        new Coordinate(105.75651799, 10.02696081),
                        new Coordinate(105.75653677, 10.02697599)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 69,
                    Price = 400,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 33,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75648916, 10.02694298),
                        new Coordinate(105.75651195, 10.02690204),
                        new Coordinate(105.75646904, 10.02687563),
                        new Coordinate(105.75643685, 10.02690798),
                        new Coordinate(105.75648916, 10.02694298)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 70,
                    Price = 400,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 33,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75641607, 10.02689544),
                        new Coordinate(105.75644289, 10.02685516),
                        new Coordinate(105.75641808, 10.02683997),
                        new Coordinate(105.75639126, 10.02688025),
                        new Coordinate(105.75641607, 10.02689544)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 71,
                    Price = 600,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 34,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75554156, 10.02683186),
                        new Coordinate(105.75552882, 10.02682658),
                        new Coordinate(105.75550736, 10.02687016),
                        new Coordinate(105.75552346, 10.02687148),
                        new Coordinate(105.75554156, 10.02683186)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 72,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 35,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75542813, 10.02720064),
                        new Coordinate(105.75550860, 10.02719139),
                        new Coordinate(105.75551463, 10.02723828),
                        new Coordinate(105.75543350, 10.02724224),
                        new Coordinate(105.75542813, 10.02720064)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 73,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 35,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75544423, 10.02733006),
                        new Coordinate(105.75552335, 10.02731949),
                        new Coordinate(105.75552067, 10.02728582),
                        new Coordinate(105.75543953, 10.02728582),
                        new Coordinate(105.75544423, 10.02733006)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 74,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 36,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75556218, 10.02762710),
                        new Coordinate(105.75558163, 10.02761587),
                        new Coordinate(105.75555548, 10.02757295),
                        new Coordinate(105.75553469, 10.02757890),
                        new Coordinate(105.75556218, 10.02762710)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 75,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 36,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75551658, 10.02754654),
                        new Coordinate(105.75554341, 10.02753466),
                        new Coordinate(105.75551323, 10.02747985),
                        new Coordinate(105.75548507, 10.02749636),
                        new Coordinate(105.75551658, 10.02754654)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 76,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 37,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75515455, 10.02794212),
                        new Coordinate(105.75518137, 10.02790316),
                        new Coordinate(105.75515656, 10.02788137),
                        new Coordinate(105.75512974, 10.02791901),
                        new Coordinate(105.75515455, 10.02794212)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 77,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 38,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75497422, 10.02724252),
                        new Coordinate(105.75500574, 10.02719762),
                        new Coordinate(105.75495143, 10.02716130),
                        new Coordinate(105.75492192, 10.02720422),
                        new Coordinate(105.75497422, 10.02724252)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 78,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 38,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75502854, 10.02716460),
                        new Coordinate(105.75497691, 10.02712564),
                        new Coordinate(105.75499903, 10.02708933),
                        new Coordinate(105.75505469, 10.02712630),
                        new Coordinate(105.75502854, 10.02716460)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 79,
                    Price = 1200,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 39,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75446055, 10.02714435),
                        new Coordinate(105.75439515, 10.02711326),
                        new Coordinate(105.75433650, 10.02721543),
                        new Coordinate(105.75440191, 10.02723875),
                        new Coordinate(105.75446055, 10.02714435)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 80,
                    Price = 1200,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 39,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75430042, 10.02740643),
                        new Coordinate(105.75435229, 10.02732092),
                        new Coordinate(105.75429365, 10.02728539),
                        new Coordinate(105.75424741, 10.02736757),
                        new Coordinate(105.75430042, 10.02740643)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 81,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 40,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75435204, 10.02670993),
                        new Coordinate(105.75431985, 10.02669276),
                        new Coordinate(105.75425414, 10.02680766),
                        new Coordinate(105.75429706, 10.02681558),
                        new Coordinate(105.75435204, 10.02670993)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 82,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 41,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75413210, 10.02660428),
                        new Coordinate(105.75409321, 10.02657787),
                        new Coordinate(105.75403956, 10.02668616),
                        new Coordinate(105.75407443, 10.02670861),
                        new Coordinate(105.75413210, 10.02660428)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 83,
                    Price = 600,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 42,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75405992, 10.02685062),
                        new Coordinate(105.75422354, 10.02693381),
                        new Coordinate(105.75425304, 10.02689155),
                        new Coordinate(105.75407602, 10.02682024),
                        new Coordinate(105.75405992, 10.02685062)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 84,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 43,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75284586, 10.02619920),
                        new Coordinate(105.75291603, 10.02608142),
                        new Coordinate(105.75285861, 10.02605158),
                        new Coordinate(105.75279323, 10.02616151),
                        new Coordinate(105.75284586, 10.02619920)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 85,
                    Price = 700,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 44,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75234428, 10.02617438),
                        new Coordinate(105.75230673, 10.02615589),
                        new Coordinate(105.75227990, 10.02620343),
                        new Coordinate(105.75231343, 10.02622588),
                        new Coordinate(105.75234428, 10.02617438)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 86,
                    Price = 700,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 44,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75226515, 10.02630908),
                        new Coordinate(105.75229197, 10.02626418),
                        new Coordinate(105.75225174, 10.02625163),
                        new Coordinate(105.75223162, 10.02628861),
                        new Coordinate(105.75226515, 10.02630908)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 87,
                    Price = 500,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 45,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75331109, 10.02519625),
                        new Coordinate(105.75334327, 10.02516786),
                        new Coordinate(105.75332919, 10.02515069),
                        new Coordinate(105.75329499, 10.02518304),
                        new Coordinate(105.75331109, 10.02519625)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 88,
                    Price = 600,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 46,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75276433, 10.02531397),
                        new Coordinate(105.75279517, 10.02525256),
                        new Coordinate(105.75277774, 10.02524266),
                        new Coordinate(105.75275091, 10.02530605),
                        new Coordinate(105.75276433, 10.02531397)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 89,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 47,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75326402, 10.02576773),
                        new Coordinate(105.75324659, 10.02572613),
                        new Coordinate(105.75319093, 10.02574792),
                        new Coordinate(105.75320501, 10.02578952),
                        new Coordinate(105.75326402, 10.02576773)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 90,
                    Price = 1100,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 47,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75316612, 10.02580801),
                        new Coordinate(105.75315003, 10.02576178),
                        new Coordinate(105.75308699, 10.02578688),
                        new Coordinate(105.75309504, 10.02583244),
                        new Coordinate(105.75316612, 10.02580801)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 91,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 48,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75159381, 10.02557786),
                        new Coordinate(105.75165166, 10.02563015),
                        new Coordinate(105.75170477, 10.02559093),
                        new Coordinate(105.75163459, 10.02553864),
                        new Coordinate(105.75159381, 10.02557786)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 92,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 48,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75169623, 10.02566003),
                        new Coordinate(105.75176735, 10.02572167),
                        new Coordinate(105.75181382, 10.02568898),
                        new Coordinate(105.75175408, 10.02563762),
                        new Coordinate(105.75169623, 10.02566003)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 93,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 48,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75186598, 10.02580571),
                        new Coordinate(105.75190391, 10.02576369),
                        new Coordinate(105.75184606, 10.02571139),
                        new Coordinate(105.75180434, 10.02574781),
                        new Coordinate(105.75186598, 10.02580571)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 94,
                    Price = 1300,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 49,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75782616, 10.02157335),
                        new Coordinate(105.75781260, 10.02153565),
                        new Coordinate(105.75774482, 10.02155764),
                        new Coordinate(105.75775519, 10.02159376),
                        new Coordinate(105.75782616, 10.02157335)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 95,
                    Price = 1300,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 49,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75770176, 10.02161025),
                        new Coordinate(105.75769299, 10.02157020),
                        new Coordinate(105.75762361, 10.02158984),
                        new Coordinate(105.75763557, 10.02162674),
                        new Coordinate(105.75770176, 10.02161025)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 96,
                    Price = 700,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 50,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75806318, 10.02164165),
                        new Coordinate(105.75816560, 10.02161924),
                        new Coordinate(105.75816181, 10.02159496),
                        new Coordinate(105.75805749, 10.02161551),
                        new Coordinate(105.75806318, 10.02164165)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 97,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 51,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75854060, 10.02167351),
                        new Coordinate(105.75858083, 10.02166427),
                        new Coordinate(105.75856340, 10.02160748),
                        new Coordinate(105.75852384, 10.02161012),
                        new Coordinate(105.75854060, 10.02167351)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 98,
                    Price = 900,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 51,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75850841, 10.02155201),
                        new Coordinate(105.75854664, 10.02153683),
                        new Coordinate(105.75852987, 10.02147938),
                        new Coordinate(105.75849299, 10.02148994),
                        new Coordinate(105.75850841, 10.02155201)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 99,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 52,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75958459, 10.02183993),
                        new Coordinate(105.75962750, 10.02189606),
                        new Coordinate(105.75965567, 10.02189011),
                        new Coordinate(105.75961141, 10.02182210),
                        new Coordinate(105.75958459, 10.02183993)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 100,
                    Price = 1000,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 52,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75968785, 10.02198058),
                        new Coordinate(105.75972943, 10.02195218),
                        new Coordinate(105.75970394, 10.02191851),
                        new Coordinate(105.75966304, 10.02194426),
                        new Coordinate(105.75968785, 10.02198058)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 101,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 53,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75965030, 10.02176201),
                        new Coordinate(105.75967377, 10.02179503),
                        new Coordinate(105.75970797, 10.02178182),
                        new Coordinate(105.75968584, 10.02174088),
                        new Coordinate(105.75965030, 10.02176201)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 102,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = true,
                    IsMezzanine = false,
                    MotelId = 53,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75968383, 10.02181880),
                        new Coordinate(105.75971870, 10.02187163),
                        new Coordinate(105.75977502, 10.02185644),
                        new Coordinate(105.75974485, 10.02180890),
                        new Coordinate(105.75968383, 10.02181880)
                    ]))
                    { SRID = 4326 },
                },
                new Room
                {
                    Id = 103,
                    Price = 800,
                    Capability = 1,
                    Descripption = "Mô tả cho phòng",
                    IsAvailable = false,
                    IsMezzanine = false,
                    MotelId = 53,
                    Geom = new Polygon(new LinearRing(
                    [
                        new Coordinate(105.75976094, 10.02193766),
                        new Coordinate(105.75980855, 10.02190464),
                        new Coordinate(105.75979112, 10.02187757),
                        new Coordinate(105.75974686, 10.02191389),
                        new Coordinate(105.75976094, 10.02193766)
                    ]))
                    { SRID = 4326 },
                });

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