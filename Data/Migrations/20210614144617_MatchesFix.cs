using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentsWebApp.Data.Migrations
{
    public partial class MatchesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Matches_nextMatchID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_nextMatchID",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "nextMatchID",
                table: "Matches",
                newName: "nextMatchNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nextMatchNumber",
                table: "Matches",
                newName: "nextMatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_nextMatchID",
                table: "Matches",
                column: "nextMatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Matches_nextMatchID",
                table: "Matches",
                column: "nextMatchID",
                principalTable: "Matches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
