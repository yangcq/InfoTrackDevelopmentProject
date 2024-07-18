using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScrapeDBContext.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashValue",
                table: "Searches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Searches_HashValue",
                table: "Searches",
                column: "HashValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Searches_HashValue",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "HashValue",
                table: "Searches");
        }
    }
}
