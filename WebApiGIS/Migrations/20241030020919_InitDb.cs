using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiGIS.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Dob = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Motels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Geom = table.Column<Geometry>(type: "geometry", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotelImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    MotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotelImages_Motels_MotelId",
                        column: x => x.MotelId,
                        principalTable: "Motels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Capability = table.Column<int>(type: "integer", nullable: false),
                    IsMezzanine = table.Column<bool>(type: "boolean", nullable: false),
                    IsAvaileble = table.Column<bool>(type: "boolean", nullable: false),
                    Descripption = table.Column<string>(type: "text", nullable: false),
                    Geom = table.Column<Geometry>(type: "geometry", nullable: false),
                    MotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Motels_MotelId",
                        column: x => x.MotelId,
                        principalTable: "Motels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EquipmentTypeId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EquipmentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Điện lạnh" },
                    { 2, "Gia dụng" },
                    { 3, "Khác" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ADMIN" },
                    { 2, "OWNER" },
                    { 3, "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Dob", "Email", "Name", "Password", "PhoneNumber", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, "N/A", new DateOnly(1, 1, 1), "N/A", "NoUser", "N/A", "N/A", 1, null },
                    { 2, "no_avatar.jpg", new DateOnly(2004, 10, 30), "admin@gmail.com", "Administrator", "$2a$11$ICdO8d0/rsTc2FnpksmaTuAb0StXQtMzi33RKIyQmcFWOt.NkOgpq", "0829376780", 1, null },
                    { 3, "no_avatar.jpg", new DateOnly(1994, 10, 30), "owner@gmail.com", "Owner", "$2a$11$N0poLQaIEjzfzpL6gkP/TuL4H82dEsjrBntmImkx9MTvvVjbKupti", "0829876785", 2, null },
                    { 4, "no_avatar.jpg", new DateOnly(1999, 10, 30), "user@gmail.com", "User", "$2a$11$pVgykLhUd4tLn2pYOIuDPevwMKsuZra5JcQwAmA7ZjRIjSGk/dOmu", "0829123746", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Motels",
                columns: new[] { "Id", "Description", "Geom", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Đây là mô tả cho khu nhà trọ của cô Bảy", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (105.766652 10.026272)"), "Nhà Trọ Cô Bảy", 1 },
                    { 2, "Đây là mô tả cho khu nhà trọ sinh viên", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (105.766984 10.025973)"), "Nhà Trọ Sinh Viên", 3 },
                    { 3, "Đây là mô tả cho khu nhà trọ sinh viên", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (105.766292 10.026623)"), "Nhà Trọ Cẩm Tú", 1 }
                });

            migrationBuilder.InsertData(
                table: "MotelImages",
                columns: new[] { "Id", "MotelId", "Path" },
                values: new object[,]
                {
                    { 1, 1, "motel1_image1.jpg" },
                    { 2, 1, "motel1_image2.jpg" },
                    { 3, 1, "motel1_image3.jpg" },
                    { 4, 2, "motel2_image1.jpg" },
                    { 5, 2, "motel2_image2.jpg" },
                    { 6, 2, "motel2_image3.jpg" },
                    { 7, 3, "motel3_image1.jpg" },
                    { 8, 3, "motel3_image2.jpg" },
                    { 9, 3, "motel3_image3.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capability", "Descripption", "Geom", "IsAvaileble", "IsMezzanine", "MotelId", "Price" },
                values: new object[,]
                {
                    { 1, 2, "Mô tả cho phòng", (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((105.7662 10.026, 105.7665 10.026, 105.7665 10.0263, 105.7662 10.0263, 105.7662 10.026))"), true, true, 1, 1200 },
                    { 2, 2, "Mô tả cho phòng", (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((105.7667 10.026, 105.767 10.026, 105.767 10.0263, 105.7667 10.0263, 105.7667 10.026))"), true, true, 1, 1200 },
                    { 3, 2, "Mô tả cho phòng", (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((105.7672 10.0261, 105.7675 10.0261, 105.7675 10.0264, 105.7672 10.0264, 105.7672 10.0261))"), true, true, 1, 1300 },
                    { 4, 3, "Mô tả cho phòng", (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((105.7668 10.0258, 105.767 10.0258, 105.767 10.026, 105.7668 10.026, 105.7668 10.0258))"), false, true, 2, 1500 },
                    { 5, 3, "Mô tả cho phòng", (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((105.7666 10.0257, 105.7669 10.0257, 105.7669 10.0259, 105.7666 10.0259, 105.7666 10.0257))"), false, true, 2, 1500 },
                    { 6, 3, "Mô tả cho phòng", (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((105.7671 10.0259, 105.7673 10.0259, 105.7673 10.0261, 105.7671 10.0261, 105.7671 10.0259))"), true, true, 2, 1500 },
                    { 7, 1, "Mô tả cho phòng", (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((105.7661 10.0265, 105.7663 10.0265, 105.7663 10.0267, 105.7661 10.0267, 105.7661 10.0265))"), false, false, 3, 800 },
                    { 8, 1, "Mô tả cho phòng", (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((105.7663 10.0266, 105.7665 10.0266, 105.7665 10.0268, 105.7663 10.0268, 105.7663 10.0266))"), false, false, 3, 800 },
                    { 9, 1, "Mô tả cho phòng", (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((105.7662 10.0268, 105.7664 10.0268, 105.7664 10.027, 105.7662 10.027, 105.7662 10.0268))"), true, false, 3, 800 }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "EquipmentTypeId", "Name", "RoomId" },
                values: new object[,]
                {
                    { 1, "Đây là mô tả cho tủ lạnh của nhà trọ", 1, "Tủ lạnh", 1 },
                    { 2, "Đây là mô tả cho cái bàn của nhà trọ", 3, "Bàn", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentTypeId",
                table: "Equipments",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_RoomId",
                table: "Equipments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MotelImages_MotelId",
                table: "MotelImages",
                column: "MotelId");

            migrationBuilder.CreateIndex(
                name: "IX_MotelImages_Path",
                table: "MotelImages",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motels_UserId",
                table: "Motels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_MotelId",
                table: "Rooms",
                column: "MotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "MotelImages");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Motels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
