using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiGIS.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(2004, 11, 11), "$2a$11$9Wim4FkKMJi3avGUqd51Ke9v7rs5bQW/VE6J.tThPVRK6cHV/ZQry" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1994, 11, 11), "$2a$11$fP3ocSMuIEXgI1ix8K0D9uc9aRcNroVb4DnV3TOvFZsovfNmCcmFW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateOnly(1999, 11, 11), "$2a$11$Mv0nMcC83simMhAJjcEaHeVvHFYfSSpdnT2wI/GXRNxfGhVaZiHxS" });
        }
    }
}
