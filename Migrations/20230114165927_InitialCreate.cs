using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zbor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPlecare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NrLocuri = table.Column<int>(type: "int", nullable: false),
                    NrLocuriRezervate = table.Column<int>(type: "int", nullable: false),
                    Poarta = table.Column<int>(type: "int", nullable: false),
                    OreIntarziere = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zbor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zbor");
        }
    }
}
