using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCvs_CVStatuses_LocalAgentStatusId",
                table: "SelectedCvs");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCvs_HRPools_HRPoolIDId",
                table: "SelectedCvs");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCvs_LocalAgents_LocalAgentId",
                table: "SelectedCvs");

            migrationBuilder.DropIndex(
                name: "IX_SelectedCvs_HRPoolIDId",
                table: "SelectedCvs");

            migrationBuilder.DropColumn(
                name: "HRPoolIDId",
                table: "SelectedCvs");

            migrationBuilder.AlterColumn<int>(
                name: "LocalAgentStatusId",
                table: "SelectedCvs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalAgentId",
                table: "SelectedCvs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HRPoolId",
                table: "SelectedCvs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCvs_HRPoolId",
                table: "SelectedCvs",
                column: "HRPoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCvs_CVStatuses_LocalAgentStatusId",
                table: "SelectedCvs",
                column: "LocalAgentStatusId",
                principalTable: "CVStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCvs_HRPools_HRPoolId",
                table: "SelectedCvs",
                column: "HRPoolId",
                principalTable: "HRPools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCvs_LocalAgents_LocalAgentId",
                table: "SelectedCvs",
                column: "LocalAgentId",
                principalTable: "LocalAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCvs_CVStatuses_LocalAgentStatusId",
                table: "SelectedCvs");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCvs_HRPools_HRPoolId",
                table: "SelectedCvs");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCvs_LocalAgents_LocalAgentId",
                table: "SelectedCvs");

            migrationBuilder.DropIndex(
                name: "IX_SelectedCvs_HRPoolId",
                table: "SelectedCvs");

            migrationBuilder.DropColumn(
                name: "HRPoolId",
                table: "SelectedCvs");

            migrationBuilder.AlterColumn<int>(
                name: "LocalAgentStatusId",
                table: "SelectedCvs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocalAgentId",
                table: "SelectedCvs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HRPoolIDId",
                table: "SelectedCvs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCvs_HRPoolIDId",
                table: "SelectedCvs",
                column: "HRPoolIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCvs_CVStatuses_LocalAgentStatusId",
                table: "SelectedCvs",
                column: "LocalAgentStatusId",
                principalTable: "CVStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCvs_HRPools_HRPoolIDId",
                table: "SelectedCvs",
                column: "HRPoolIDId",
                principalTable: "HRPools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCvs_LocalAgents_LocalAgentId",
                table: "SelectedCvs",
                column: "LocalAgentId",
                principalTable: "LocalAgents",
                principalColumn: "Id");
        }
    }
}
