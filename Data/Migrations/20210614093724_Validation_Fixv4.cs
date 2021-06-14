using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentsWebApp.Data.Migrations
{
    public partial class Validation_Fixv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isBracket",
                table: "Tournament",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBracket",
                table: "Tournament");
        }
    }
}
