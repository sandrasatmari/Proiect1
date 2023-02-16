using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect1.Migrations
{
    public partial class porti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanieZbor_CompanieAeriana_CompanieAerianaID",
                table: "CompanieZbor");

            migrationBuilder.DropColumn(
                name: "Poarta",
                table: "Zbor");

            migrationBuilder.AddColumn<int>(
                name: "PoartaID",
                table: "Zbor",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanieAerianaID",
                table: "CompanieZbor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Poarta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numar = table.Column<int>(type: "int", nullable: false),
                    Terminal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poarta", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zbor_PoartaID",
                table: "Zbor",
                column: "PoartaID");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanieZbor_CompanieAeriana_CompanieAerianaID",
                table: "CompanieZbor",
                column: "CompanieAerianaID",
                principalTable: "CompanieAeriana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zbor_Poarta_PoartaID",
                table: "Zbor",
                column: "PoartaID",
                principalTable: "Poarta",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanieZbor_CompanieAeriana_CompanieAerianaID",
                table: "CompanieZbor");

            migrationBuilder.DropForeignKey(
                name: "FK_Zbor_Poarta_PoartaID",
                table: "Zbor");

            migrationBuilder.DropTable(
                name: "Poarta");

            migrationBuilder.DropIndex(
                name: "IX_Zbor_PoartaID",
                table: "Zbor");

            migrationBuilder.DropColumn(
                name: "PoartaID",
                table: "Zbor");

            migrationBuilder.AddColumn<int>(
                name: "Poarta",
                table: "Zbor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CompanieAerianaID",
                table: "CompanieZbor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanieZbor_CompanieAeriana_CompanieAerianaID",
                table: "CompanieZbor",
                column: "CompanieAerianaID",
                principalTable: "CompanieAeriana",
                principalColumn: "ID");
        }
    }
}
