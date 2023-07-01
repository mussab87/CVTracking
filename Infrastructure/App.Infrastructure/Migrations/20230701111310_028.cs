using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _028 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MusanedContractDate",
                table: "SelectedCvs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MusanedContractNo",
                table: "SelectedCvs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusanedContractDate",
                table: "SelectedCvs");

            migrationBuilder.DropColumn(
                name: "MusanedContractNo",
                table: "SelectedCvs");
        }
    }
}
