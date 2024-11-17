using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiGIS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Dob",
                table: "Users",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Dob",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dob", "Password", "UserId" },
                values: new object[] { new DateOnly(2004, 11, 3), "$2a$11$5eIEERNxTyMadS1Ql5OHT.sgySEJbV0Ul.KEy.1.UDAM8Il0IZqii", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Dob", "Password", "UserId" },
                values: new object[] { new DateOnly(1994, 11, 3), "$2a$11$TFDi9xNAVb.dyGRN7RZiZ.mdZvSJalY6eRllsKJfLUS7H4WHl3npa", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Dob", "Password", "UserId" },
                values: new object[] { new DateOnly(1999, 11, 3), "$2a$11$d0PbJx/OLL0O.wDOKxAAzOSIFoHv/e8hk0f4fzhCT3T2kZclnFOCe", null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
