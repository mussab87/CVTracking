using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _37 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreviousEmployments_Designations_DesignationId",
                table: "PreviousEmployments");

            migrationBuilder.DropIndex(
                name: "IX_PreviousEmployments_DesignationId",
                table: "PreviousEmployments");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "PreviousEmployments");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEmployments_PositionId",
                table: "PreviousEmployments",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousEmployments_Designations_PositionId",
                table: "PreviousEmployments",
                column: "PositionId",
                principalTable: "Designations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreviousEmployments_Designations_PositionId",
                table: "PreviousEmployments");

            migrationBuilder.DropIndex(
                name: "IX_PreviousEmployments_PositionId",
                table: "PreviousEmployments");

            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "PreviousEmployments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEmployments_DesignationId",
                table: "PreviousEmployments",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousEmployments_Designations_DesignationId",
                table: "PreviousEmployments",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id");
        }
    }
}
