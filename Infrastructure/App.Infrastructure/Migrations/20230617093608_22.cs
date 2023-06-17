using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocalAgentName",
                table: "LocalAgents",
                newName: "LocalAgentNameEnglish");

            migrationBuilder.AddColumn<string>(
                name: "LocalAgentNameArabic",
                table: "LocalAgents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalAgentNameArabic",
                table: "LocalAgents");

            migrationBuilder.RenameColumn(
                name: "LocalAgentNameEnglish",
                table: "LocalAgents",
                newName: "LocalAgentName");
        }
    }
}
