using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _019 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateSkils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSkils_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateSkils_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVCandidateSkils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    CandidateSkilsId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVCandidateSkils", x => new { x.CVId, x.CandidateSkilsId });
                    table.ForeignKey(
                        name: "FK_CVCandidateSkils_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVCandidateSkils_CandidateSkils_CandidateSkilsId",
                        column: x => x.CandidateSkilsId,
                        principalTable: "CandidateSkils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVCandidateSkils_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVCandidateSkils_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkils_CreatedById",
                table: "CandidateSkils",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkils_LastModifiedById",
                table: "CandidateSkils",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CVCandidateSkils_CandidateSkilsId",
                table: "CVCandidateSkils",
                column: "CandidateSkilsId");

            migrationBuilder.CreateIndex(
                name: "IX_CVCandidateSkils_CreatedById",
                table: "CVCandidateSkils",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CVCandidateSkils_LastModifiedById",
                table: "CVCandidateSkils",
                column: "LastModifiedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVCandidateSkils");

            migrationBuilder.DropTable(
                name: "CandidateSkils");
        }
    }
}
