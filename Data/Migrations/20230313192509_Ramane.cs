using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Data.Migrations
{
    public partial class Ramane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pret_Final",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Pret_Manopera",
                table: "Activities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Pret_Final",
                table: "Activities",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Pret_Manopera",
                table: "Activities",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
