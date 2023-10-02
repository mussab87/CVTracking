using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _035 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "CVs");

            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "CVs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "CVs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignationArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Designations_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Educations_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVs_DesignationId",
                table: "CVs",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_EducationId",
                table: "CVs",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_CreatedById",
                table: "Designations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_LastModifiedById",
                table: "Designations",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CreatedById",
                table: "Educations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_LastModifiedById",
                table: "Educations",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Designations_DesignationId",
                table: "CVs",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Educations_EducationId",
                table: "CVs",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Designations_DesignationId",
                table: "CVs");

            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Educations_EducationId",
                table: "CVs");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_CVs_DesignationId",
                table: "CVs");

            migrationBuilder.DropIndex(
                name: "IX_CVs_EducationId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "CVs");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
