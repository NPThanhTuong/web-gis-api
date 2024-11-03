using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiGIS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIsAvailableField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvaileble",
                table: "Rooms",
                newName: "IsAvailable");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(2004, 11, 3), "$2a$11$5eIEERNxTyMadS1Ql5OHT.sgySEJbV0Ul.KEy.1.UDAM8Il0IZqii" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1994, 11, 3), "$2a$11$TFDi9xNAVb.dyGRN7RZiZ.mdZvSJalY6eRllsKJfLUS7H4WHl3npa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1999, 11, 3), "$2a$11$d0PbJx/OLL0O.wDOKxAAzOSIFoHv/e8hk0f4fzhCT3T2kZclnFOCe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Rooms",
                newName: "IsAvaileble");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(2004, 10, 30), "$2a$11$OGI2IDoda360hds6.SP/Be8IFLD7V3Tc5I44a8gH/T0RgrKqiPjGi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1994, 10, 30), "$2a$11$Gvg/eTxKkp7ye2GdtNn51.h7fshICIcD1scUCga41.XDO9HOYxtTS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1999, 10, 30), "$2a$11$3h4pYY8204geNugv520DHeyisK9Am6eiAj1chvOdRpLSFxIuEmaMC" });
        }
    }
}
