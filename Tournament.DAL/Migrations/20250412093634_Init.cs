using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TournamentsOfSpanish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountWin = table.Column<int>(type: "int", nullable: false),
                    CountDefeat = table.Column<int>(type: "int", nullable: false),
                    CountDraw = table.Column<int>(type: "int", nullable: false),
                    CountGoals = table.Column<int>(type: "int", nullable: false),
                    CountSkipGoals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentsOfSpanish", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentsOfSpanish");
        }
    }
}
