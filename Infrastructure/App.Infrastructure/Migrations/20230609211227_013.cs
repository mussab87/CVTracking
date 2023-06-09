using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _013 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_MartialStatus_ReligionId",
                table: "CVs");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_MartialStatusId",
                table: "CVs",
                column: "MartialStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_MartialStatus_MartialStatusId",
                table: "CVs",
                column: "MartialStatusId",
                principalTable: "MartialStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_MartialStatus_MartialStatusId",
                table: "CVs");

            migrationBuilder.DropIndex(
                name: "IX_CVs_MartialStatusId",
                table: "CVs");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_MartialStatus_ReligionId",
                table: "CVs",
                column: "ReligionId",
                principalTable: "MartialStatus",
                principalColumn: "Id");
        }
    }
}
