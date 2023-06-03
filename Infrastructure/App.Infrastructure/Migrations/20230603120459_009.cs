using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RootCompanies_Cities_RootCompanyCountryCityId",
                table: "RootCompanies");

            migrationBuilder.RenameColumn(
                name: "RootCompanyCountryCityId",
                table: "RootCompanies",
                newName: "RootCompanyCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_RootCompanies_RootCompanyCountryCityId",
                table: "RootCompanies",
                newName: "IX_RootCompanies_RootCompanyCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RootCompanies_Countries_RootCompanyCountryId",
                table: "RootCompanies",
                column: "RootCompanyCountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RootCompanies_Countries_RootCompanyCountryId",
                table: "RootCompanies");

            migrationBuilder.RenameColumn(
                name: "RootCompanyCountryId",
                table: "RootCompanies",
                newName: "RootCompanyCountryCityId");

            migrationBuilder.RenameIndex(
                name: "IX_RootCompanies_RootCompanyCountryId",
                table: "RootCompanies",
                newName: "IX_RootCompanies_RootCompanyCountryCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RootCompanies_Cities_RootCompanyCountryCityId",
                table: "RootCompanies",
                column: "RootCompanyCountryCityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
