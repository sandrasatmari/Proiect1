using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect1.Migrations
{
    public partial class mimi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zbor_CompanieAeriana_CompanieAerianaID",
                table: "Zbor");

            migrationBuilder.DropIndex(
                name: "IX_Zbor_CompanieAerianaID",
                table: "Zbor");

            migrationBuilder.DropColumn(
                name: "CompanieAerianaID",
                table: "Zbor");

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "CompanieAeriana",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanieAeriana_MemberID",
                table: "CompanieAeriana",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanieAeriana_Member_MemberID",
                table: "CompanieAeriana",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanieAeriana_Member_MemberID",
                table: "CompanieAeriana");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropIndex(
                name: "IX_CompanieAeriana_MemberID",
                table: "CompanieAeriana");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "CompanieAeriana");

            migrationBuilder.AddColumn<int>(
                name: "CompanieAerianaID",
                table: "Zbor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zbor_CompanieAerianaID",
                table: "Zbor",
                column: "CompanieAerianaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zbor_CompanieAeriana_CompanieAerianaID",
                table: "Zbor",
                column: "CompanieAerianaID",
                principalTable: "CompanieAeriana",
                principalColumn: "ID");
        }
    }
}
