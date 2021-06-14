using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentsWebApp.Data.Migrations
{
    public partial class Matches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    positionID = table.Column<int>(type: "int", nullable: false),
                    nextMatchID = table.Column<int>(type: "int", nullable: true),
                    OpponentFirstID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OpponentSecondID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TournamentID = table.Column<int>(type: "int", nullable: false),
                    FirstOpponentResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondOpponentResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinnerID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Matches_AspNetUsers_OpponentFirstID",
                        column: x => x.OpponentFirstID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_AspNetUsers_OpponentSecondID",
                        column: x => x.OpponentSecondID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Matches_nextMatchID",
                        column: x => x.nextMatchID,
                        principalTable: "Matches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Tournament_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_nextMatchID",
                table: "Matches",
                column: "nextMatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_OpponentFirstID",
                table: "Matches",
                column: "OpponentFirstID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_OpponentSecondID",
                table: "Matches",
                column: "OpponentSecondID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentID",
                table: "Matches",
                column: "TournamentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
