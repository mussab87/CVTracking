using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CancelDateTime",
                table: "HRPools",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancelNotes",
                table: "HRPools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CancelReasonId",
                table: "HRPools",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledById",
                table: "HRPools",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancel",
                table: "HRPools",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CancelReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CancelReasonEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancelReasonArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CancelReasons_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CancelReasons_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HRPools_CanceledById",
                table: "HRPools",
                column: "CanceledById");

            migrationBuilder.CreateIndex(
                name: "IX_HRPools_CancelReasonId",
                table: "HRPools",
                column: "CancelReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_CancelReasons_CreatedById",
                table: "CancelReasons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CancelReasons_LastModifiedById",
                table: "CancelReasons",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_HRPools_CancelReasons_CancelReasonId",
                table: "HRPools",
                column: "CancelReasonId",
                principalTable: "CancelReasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HRPools_Users_CanceledById",
                table: "HRPools",
                column: "CanceledById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HRPools_CancelReasons_CancelReasonId",
                table: "HRPools");

            migrationBuilder.DropForeignKey(
                name: "FK_HRPools_Users_CanceledById",
                table: "HRPools");

            migrationBuilder.DropTable(
                name: "CancelReasons");

            migrationBuilder.DropIndex(
                name: "IX_HRPools_CanceledById",
                table: "HRPools");

            migrationBuilder.DropIndex(
                name: "IX_HRPools_CancelReasonId",
                table: "HRPools");

            migrationBuilder.DropColumn(
                name: "CancelDateTime",
                table: "HRPools");

            migrationBuilder.DropColumn(
                name: "CancelNotes",
                table: "HRPools");

            migrationBuilder.DropColumn(
                name: "CancelReasonId",
                table: "HRPools");

            migrationBuilder.DropColumn(
                name: "CanceledById",
                table: "HRPools");

            migrationBuilder.DropColumn(
                name: "IsCancel",
                table: "HRPools");
        }
    }
}
