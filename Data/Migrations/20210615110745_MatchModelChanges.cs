using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentsWebApp.Data.Migrations
{
    public partial class MatchModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstOpponentResult",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SecondOpponentResult",
                table: "Matches",
                newName: "TemporaryResult");

            migrationBuilder.AddColumn<bool>(
                name: "isFinished",
                table: "Matches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFinished",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "TemporaryResult",
                table: "Matches",
                newName: "SecondOpponentResult");

            migrationBuilder.AddColumn<string>(
                name: "FirstOpponentResult",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
