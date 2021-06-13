using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentsWebApp.Data.Migrations
{
    public partial class More_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tournament",
                newName: "ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Tournament",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discipline",
                table: "Tournament",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Tournament",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "currentPart",
                table: "Tournament",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "localization",
                table: "Tournament",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxPart",
                table: "Tournament",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TournamentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollments_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Tournament_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Logos_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_OwnerId",
                table: "Tournament",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ApplicationUserID",
                table: "Enrollments",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_TournamentID",
                table: "Enrollments",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Logos_TournamentId",
                table: "Logos",
                column: "TournamentId");

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

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Logos");

            migrationBuilder.DropIndex(
                name: "IX_Tournament_OwnerId",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "Discipline",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "currentPart",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "localization",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "maxPart",
                table: "Tournament");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tournament",
                newName: "Id");
        }
    }
}
