using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect1.Migrations
{
    public partial class zbor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AeroportID",
                table: "Zbor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Destinatie",
                table: "Zbor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aeroport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_Aeroport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroport", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zbor_AeroportID",
                table: "Zbor",
                column: "AeroportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zbor_Aeroport_AeroportID",
                table: "Zbor",
                column: "AeroportID",
                principalTable: "Aeroport",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zbor_Aeroport_AeroportID",
                table: "Zbor");

            migrationBuilder.DropTable(
                name: "Aeroport");

            migrationBuilder.DropIndex(
                name: "IX_Zbor_AeroportID",
                table: "Zbor");

            migrationBuilder.DropColumn(
                name: "AeroportID",
                table: "Zbor");

            migrationBuilder.DropColumn(
                name: "Destinatie",
                table: "Zbor");
        }
    }
}
