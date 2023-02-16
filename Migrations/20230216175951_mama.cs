using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect1.Migrations
{
    public partial class mama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanieAeriana_MemberID",
                table: "CompanieAeriana");

            migrationBuilder.CreateIndex(
                name: "IX_CompanieAeriana_MemberID",
                table: "CompanieAeriana",
                column: "MemberID",
                unique: true,
                filter: "[MemberID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanieAeriana_MemberID",
                table: "CompanieAeriana");

            migrationBuilder.CreateIndex(
                name: "IX_CompanieAeriana_MemberID",
                table: "CompanieAeriana",
                column: "MemberID");
        }
    }
}
