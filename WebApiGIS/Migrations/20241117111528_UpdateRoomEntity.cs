using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiGIS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripption",
                table: "Rooms",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(2004, 11, 17), "$2a$11$UbDewD5/7dkhV/.PNS/BCOC8J2bdhIbX1BPZxWXSSP.pRvs9NHVSq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1994, 11, 17), "$2a$11$BAbjfhgTbuxx4i2Uc3vOl.6NSeQhDFiZPaZtWo/g01NAxK1ts1WEG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1999, 11, 17), "$2a$11$RE67/PboyjnsvLEuyjWOFOJ1h22EucXOH9D6/g0KNkMFC07UMYHjy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Rooms",
                newName: "Descripption");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(2004, 11, 14), "$2a$11$PMYdMKKd2guxrR8zogQZjOyHzchtt8cUkyNwP6ef4FbNh5Umdq87K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1994, 11, 14), "$2a$11$UKJXXZa8dAwGLSN21h78puHFAwVfGEuTE4ctBWiJ.WJEwNrvNvTf2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1999, 11, 14), "$2a$11$4eRlrOkqrm6JBsMogUQq8uY8RdsJK1LsfjEgfzY5/d55/bs8drMLa" });
        }
    }
}
