using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalNIC.Migrations
{
    /// <inheritdoc />
    public partial class AddTransparencyStandardToSocietyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransparencyStandard",
                table: "Societies");

            migrationBuilder.AddColumn<string>(
                name: "GovernanceClassification",
                table: "Societies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TransparencyStandardId",
                table: "Societies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TransparencyStandard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransparencyStandard", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Societies_TransparencyStandardId",
                table: "Societies",
                column: "TransparencyStandardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Societies_TransparencyStandard_TransparencyStandardId",
                table: "Societies",
                column: "TransparencyStandardId",
                principalTable: "TransparencyStandard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Societies_TransparencyStandard_TransparencyStandardId",
                table: "Societies");

            migrationBuilder.DropTable(
                name: "TransparencyStandard");

            migrationBuilder.DropIndex(
                name: "IX_Societies_TransparencyStandardId",
                table: "Societies");

            migrationBuilder.DropColumn(
                name: "GovernanceClassification",
                table: "Societies");

            migrationBuilder.DropColumn(
                name: "TransparencyStandardId",
                table: "Societies");

            migrationBuilder.AddColumn<int>(
                name: "TransparencyStandard",
                table: "Societies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
