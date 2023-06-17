using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalAgentId",
                table: "HRPools",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendToLocalDateTime",
                table: "HRPools",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HRPools_LocalAgentId",
                table: "HRPools",
                column: "LocalAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HRPools_LocalAgents_LocalAgentId",
                table: "HRPools",
                column: "LocalAgentId",
                principalTable: "LocalAgents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HRPools_LocalAgents_LocalAgentId",
                table: "HRPools");

            migrationBuilder.DropIndex(
                name: "IX_HRPools_LocalAgentId",
                table: "HRPools");

            migrationBuilder.DropColumn(
                name: "LocalAgentId",
                table: "HRPools");

            migrationBuilder.DropColumn(
                name: "SendToLocalDateTime",
                table: "HRPools");
        }
    }
}
