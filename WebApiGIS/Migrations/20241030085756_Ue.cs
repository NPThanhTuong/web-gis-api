using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiGIS.Migrations
{
    /// <inheritdoc />
    public partial class Ue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$OGI2IDoda360hds6.SP/Be8IFLD7V3Tc5I44a8gH/T0RgrKqiPjGi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Gvg/eTxKkp7ye2GdtNn51.h7fshICIcD1scUCga41.XDO9HOYxtTS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$3h4pYY8204geNugv520DHeyisK9Am6eiAj1chvOdRpLSFxIuEmaMC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$ICdO8d0/rsTc2FnpksmaTuAb0StXQtMzi33RKIyQmcFWOt.NkOgpq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$N0poLQaIEjzfzpL6gkP/TuL4H82dEsjrBntmImkx9MTvvVjbKupti");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$pVgykLhUd4tLn2pYOIuDPevwMKsuZra5JcQwAmA7ZjRIjSGk/dOmu");
        }
    }
}
