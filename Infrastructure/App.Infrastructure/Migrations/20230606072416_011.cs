using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForeignAgents_Users_CreatedById",
                table: "ForeignAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignAgents_Users_LastModifiedById",
                table: "ForeignAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalAgents_Users_CreatedById",
                table: "LocalAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalAgents_Users_LastModifiedById",
                table: "LocalAgents");

            migrationBuilder.DropIndex(
                name: "IX_LocalAgents_CreatedById",
                table: "LocalAgents");

            migrationBuilder.DropIndex(
                name: "IX_LocalAgents_LastModifiedById",
                table: "LocalAgents");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgents_CreatedById",
                table: "ForeignAgents");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgents_LastModifiedById",
                table: "ForeignAgents");

            migrationBuilder.AddColumn<int>(
                name: "ForeignAgentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalAgentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedById",
                table: "LocalAgents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "LocalAgents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById1",
                table: "LocalAgents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById1",
                table: "LocalAgents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedById",
                table: "ForeignAgents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "ForeignAgents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById1",
                table: "ForeignAgents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById1",
                table: "ForeignAgents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalAgents_CreatedById1",
                table: "LocalAgents",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_LocalAgents_LastModifiedById1",
                table: "LocalAgents",
                column: "LastModifiedById1");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgents_CreatedById1",
                table: "ForeignAgents",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgents_LastModifiedById1",
                table: "ForeignAgents",
                column: "LastModifiedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignAgents_Users_CreatedById1",
                table: "ForeignAgents",
                column: "CreatedById1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignAgents_Users_LastModifiedById1",
                table: "ForeignAgents",
                column: "LastModifiedById1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalAgents_Users_CreatedById1",
                table: "LocalAgents",
                column: "CreatedById1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalAgents_Users_LastModifiedById1",
                table: "LocalAgents",
                column: "LastModifiedById1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForeignAgents_Users_CreatedById1",
                table: "ForeignAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignAgents_Users_LastModifiedById1",
                table: "ForeignAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalAgents_Users_CreatedById1",
                table: "LocalAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalAgents_Users_LastModifiedById1",
                table: "LocalAgents");

            migrationBuilder.DropIndex(
                name: "IX_LocalAgents_CreatedById1",
                table: "LocalAgents");

            migrationBuilder.DropIndex(
                name: "IX_LocalAgents_LastModifiedById1",
                table: "LocalAgents");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgents_CreatedById1",
                table: "ForeignAgents");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgents_LastModifiedById1",
                table: "ForeignAgents");

            migrationBuilder.DropColumn(
                name: "ForeignAgentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LocalAgentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "LocalAgents");

            migrationBuilder.DropColumn(
                name: "LastModifiedById1",
                table: "LocalAgents");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "ForeignAgents");

            migrationBuilder.DropColumn(
                name: "LastModifiedById1",
                table: "ForeignAgents");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedById",
                table: "LocalAgents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "LocalAgents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedById",
                table: "ForeignAgents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "ForeignAgents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalAgents_CreatedById",
                table: "LocalAgents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LocalAgents_LastModifiedById",
                table: "LocalAgents",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgents_CreatedById",
                table: "ForeignAgents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgents_LastModifiedById",
                table: "ForeignAgents",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignAgents_Users_CreatedById",
                table: "ForeignAgents",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignAgents_Users_LastModifiedById",
                table: "ForeignAgents",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalAgents_Users_CreatedById",
                table: "LocalAgents",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalAgents_Users_LastModifiedById",
                table: "LocalAgents",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
