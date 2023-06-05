using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RootCompanies_Users_CreatedById",
                table: "RootCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_RootCompanies_Users_LastModifiedById",
                table: "RootCompanies");

            migrationBuilder.DropIndex(
                name: "IX_RootCompanies_CreatedById",
                table: "RootCompanies");

            migrationBuilder.DropIndex(
                name: "IX_RootCompanies_LastModifiedById",
                table: "RootCompanies");

            migrationBuilder.AddColumn<int>(
                name: "RootCompanyId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedById",
                table: "RootCompanies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "RootCompanies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById1",
                table: "RootCompanies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById1",
                table: "RootCompanies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanies_CreatedById1",
                table: "RootCompanies",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanies_LastModifiedById1",
                table: "RootCompanies",
                column: "LastModifiedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_RootCompanies_Users_CreatedById1",
                table: "RootCompanies",
                column: "CreatedById1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RootCompanies_Users_LastModifiedById1",
                table: "RootCompanies",
                column: "LastModifiedById1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RootCompanies_Users_CreatedById1",
                table: "RootCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_RootCompanies_Users_LastModifiedById1",
                table: "RootCompanies");

            migrationBuilder.DropIndex(
                name: "IX_RootCompanies_CreatedById1",
                table: "RootCompanies");

            migrationBuilder.DropIndex(
                name: "IX_RootCompanies_LastModifiedById1",
                table: "RootCompanies");

            migrationBuilder.DropColumn(
                name: "RootCompanyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "RootCompanies");

            migrationBuilder.DropColumn(
                name: "LastModifiedById1",
                table: "RootCompanies");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedById",
                table: "RootCompanies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "RootCompanies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanies_CreatedById",
                table: "RootCompanies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanies_LastModifiedById",
                table: "RootCompanies",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_RootCompanies_Users_CreatedById",
                table: "RootCompanies",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RootCompanies_Users_LastModifiedById",
                table: "RootCompanies",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
