using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingChallengeEndava.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<int>(type: "INTEGER", nullable: true),
                    Score = table.Column<int>(type: "INTEGER", nullable: true),
                    Descendants = table.Column<int>(type: "INTEGER", nullable: true),
                    ExternalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    By = table.Column<string>(type: "TEXT", nullable: true),
                    Kids = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_ExternalId",
                table: "Stories",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_Id",
                table: "Stories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_Title_ExternalId",
                table: "Stories",
                columns: new[] { "Title", "ExternalId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}
