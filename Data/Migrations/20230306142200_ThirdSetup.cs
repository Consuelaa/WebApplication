using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Data.Migrations
{
    public partial class ThirdSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status_plata",
                table: "Activities",
                newName: "Status Plata");

            migrationBuilder.RenameColumn(
                name: "Pret_Manopera",
                table: "Activities",
                newName: "Pret/Manopera");

            migrationBuilder.RenameColumn(
                name: "Pret_Final",
                table: "Activities",
                newName: "Total Pret");

            migrationBuilder.RenameColumn(
                name: "Pret_Element",
                table: "Activities",
                newName: "Pret/Element");

            migrationBuilder.RenameColumn(
                name: "Data_incasarii",
                table: "Activities",
                newName: "Data Incasarii");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total Pret",
                table: "Activities",
                newName: "Pret_Final");

            migrationBuilder.RenameColumn(
                name: "Status Plata",
                table: "Activities",
                newName: "Status_plata");

            migrationBuilder.RenameColumn(
                name: "Pret/Manopera",
                table: "Activities",
                newName: "Pret_Manopera");

            migrationBuilder.RenameColumn(
                name: "Pret/Element",
                table: "Activities",
                newName: "Pret_Element");

            migrationBuilder.RenameColumn(
                name: "Data Incasarii",
                table: "Activities",
                newName: "Data_incasarii");
        }
    }
}
