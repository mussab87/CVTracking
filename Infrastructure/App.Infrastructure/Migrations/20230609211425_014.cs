using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Religions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Religions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "Religions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Religions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "MartialStatus",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MartialStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "MartialStatus",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "MartialStatus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Religions_CreatedById",
                table: "Religions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Religions_LastModifiedById",
                table: "Religions",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_MartialStatus_CreatedById",
                table: "MartialStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MartialStatus_LastModifiedById",
                table: "MartialStatus",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_MartialStatus_Users_CreatedById",
                table: "MartialStatus",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MartialStatus_Users_LastModifiedById",
                table: "MartialStatus",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Religions_Users_CreatedById",
                table: "Religions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Religions_Users_LastModifiedById",
                table: "Religions",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MartialStatus_Users_CreatedById",
                table: "MartialStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_MartialStatus_Users_LastModifiedById",
                table: "MartialStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_Religions_Users_CreatedById",
                table: "Religions");

            migrationBuilder.DropForeignKey(
                name: "FK_Religions_Users_LastModifiedById",
                table: "Religions");

            migrationBuilder.DropIndex(
                name: "IX_Religions_CreatedById",
                table: "Religions");

            migrationBuilder.DropIndex(
                name: "IX_Religions_LastModifiedById",
                table: "Religions");

            migrationBuilder.DropIndex(
                name: "IX_MartialStatus_CreatedById",
                table: "MartialStatus");

            migrationBuilder.DropIndex(
                name: "IX_MartialStatus_LastModifiedById",
                table: "MartialStatus");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Religions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Religions");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Religions");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Religions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MartialStatus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MartialStatus");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "MartialStatus");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "MartialStatus");
        }
    }
}
