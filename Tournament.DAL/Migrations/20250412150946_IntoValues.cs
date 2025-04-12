using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IntoValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TournamentsOfSpanish",
                columns: new[] { "Id", "NameTeam", "NameCity", "CountWin", "CountDefeat", "CountDraw", "CountGoals", "CountSkipGoals" },
                values: new object[,]
                {
                    {  1, "Real Madrid", "Madrid", 26, 4, 4, 82, 30 },
                    { 2, "Barcelona", "Barcelona", 24, 5, 5, 78, 28 },
                    { 3, "Atletico Madrid", "Madrid", 22, 6, 6, 70, 32 },
                    { 4, "Sevilla", "Sevilla", 20, 8, 6, 65, 35 },
                    { 5, "Real Betis", "Sevilla", 18, 10, 6, 60, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
