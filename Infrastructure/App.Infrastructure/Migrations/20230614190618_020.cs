using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _020 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVCandidateSkils_CandidateSkils_CandidateSkilsId",
                table: "CVCandidateSkils");

            migrationBuilder.RenameColumn(
                name: "CandidateSkilsId",
                table: "CVCandidateSkils",
                newName: "CandidateSkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_CVCandidateSkils_CandidateSkilsId",
                table: "CVCandidateSkils",
                newName: "IX_CVCandidateSkils_CandidateSkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVCandidateSkils_CandidateSkils_CandidateSkillsId",
                table: "CVCandidateSkils",
                column: "CandidateSkillsId",
                principalTable: "CandidateSkils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVCandidateSkils_CandidateSkils_CandidateSkillsId",
                table: "CVCandidateSkils");

            migrationBuilder.RenameColumn(
                name: "CandidateSkillsId",
                table: "CVCandidateSkils",
                newName: "CandidateSkilsId");

            migrationBuilder.RenameIndex(
                name: "IX_CVCandidateSkils_CandidateSkillsId",
                table: "CVCandidateSkils",
                newName: "IX_CVCandidateSkils_CandidateSkilsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVCandidateSkils_CandidateSkils_CandidateSkilsId",
                table: "CVCandidateSkils",
                column: "CandidateSkilsId",
                principalTable: "CandidateSkils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
