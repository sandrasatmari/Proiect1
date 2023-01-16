using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect1.Migrations
{
    public partial class CompanieZbor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanieAeriana",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallCenter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailContact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanieAeriana", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CompanieZbor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZborID = table.Column<int>(type: "int", nullable: true),
                    CompanieAerianaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanieZbor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanieZbor_CompanieAeriana_CompanieAerianaID",
                        column: x => x.CompanieAerianaID,
                        principalTable: "CompanieAeriana",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CompanieZbor_Zbor_ZborID",
                        column: x => x.ZborID,
                        principalTable: "Zbor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanieZbor_CompanieAerianaID",
                table: "CompanieZbor",
                column: "CompanieAerianaID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanieZbor_ZborID",
                table: "CompanieZbor",
                column: "ZborID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanieZbor");

            migrationBuilder.DropTable(
                name: "CompanieAeriana");
        }
    }
}
