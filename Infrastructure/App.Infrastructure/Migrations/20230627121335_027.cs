using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _027 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceOfIssue",
                table: "CVs");

            migrationBuilder.AddColumn<int>(
                name: "PlaceOfIssueId",
                table: "CVs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CVs_PlaceOfIssueId",
                table: "CVs",
                column: "PlaceOfIssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Cities_PlaceOfIssueId",
                table: "CVs",
                column: "PlaceOfIssueId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Cities_PlaceOfIssueId",
                table: "CVs");

            migrationBuilder.DropIndex(
                name: "IX_CVs_PlaceOfIssueId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "PlaceOfIssueId",
                table: "CVs");

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfIssue",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
