using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amprentare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pacient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manopera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Componente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elemente = table.Column<int>(type: "int", nullable: false),
                    Pret_Element = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pret_Manopera = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adaos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pret_Final = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status_plata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Livrare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_incasarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mentiuni = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");
        }
    }
}
