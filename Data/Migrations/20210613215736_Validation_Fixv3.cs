using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentsWebApp.Data.Migrations
{
    public partial class Validation_Fixv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_AspNetUsers_OwnerId",
                table: "Tournament");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tournament",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "LicenceNumber",
                table: "Enrollments",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Ranking",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_AspNetUsers_OwnerId",
                table: "Tournament",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_AspNetUsers_OwnerId",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "LicenceNumber",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "Enrollments");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tournament",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_AspNetUsers_OwnerId",
                table: "Tournament",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
