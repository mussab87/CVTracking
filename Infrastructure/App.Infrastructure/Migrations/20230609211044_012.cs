using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Religion",
                table: "CVs");

            migrationBuilder.RenameColumn(
                name: "MartialStatus",
                table: "CVs",
                newName: "ReligionId");

            migrationBuilder.AddColumn<int>(
                name: "MartialStatusId",
                table: "CVs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MartialStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MartialStatusEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MartialStatusArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MartialStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligionArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVs_ReligionId",
                table: "CVs",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_MartialStatus_ReligionId",
                table: "CVs",
                column: "ReligionId",
                principalTable: "MartialStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Religions_ReligionId",
                table: "CVs",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_MartialStatus_ReligionId",
                table: "CVs");

            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Religions_ReligionId",
                table: "CVs");

            migrationBuilder.DropTable(
                name: "MartialStatus");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropIndex(
                name: "IX_CVs_ReligionId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "MartialStatusId",
                table: "CVs");

            migrationBuilder.RenameColumn(
                name: "ReligionId",
                table: "CVs",
                newName: "MartialStatus");

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
