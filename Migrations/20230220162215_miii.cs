using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect1.Migrations
{
    public partial class miii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanieAeriana_Member_MemberID",
                table: "CompanieAeriana");

            migrationBuilder.DropIndex(
                name: "IX_CompanieAeriana_MemberID",
                table: "CompanieAeriana");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "CompanieAeriana");

            migrationBuilder.AddColumn<int>(
                name: "CompanieAerianaID",
                table: "Member",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_CompanieAerianaID",
                table: "Member",
                column: "CompanieAerianaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_CompanieAeriana_CompanieAerianaID",
                table: "Member",
                column: "CompanieAerianaID",
                principalTable: "CompanieAeriana",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_CompanieAeriana_CompanieAerianaID",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_CompanieAerianaID",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "CompanieAerianaID",
                table: "Member");

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "CompanieAeriana",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanieAeriana_MemberID",
                table: "CompanieAeriana",
                column: "MemberID",
                unique: true,
                filter: "[MemberID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanieAeriana_Member_MemberID",
                table: "CompanieAeriana",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID");
        }
    }
}
