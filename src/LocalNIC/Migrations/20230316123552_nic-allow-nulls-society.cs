using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalNIC.Migrations
{
    /// <inheritdoc />
    public partial class nicallownullssociety : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Societies_SecondSubclasses_SecondSubclassId",
                table: "Societies");

            migrationBuilder.AlterColumn<Guid>(
                name: "SecondSubclassId",
                table: "Societies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Societies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LicenseEndDate",
                table: "Societies",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "ProviderContactDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Societies_SecondSubclasses_SecondSubclassId",
                table: "Societies",
                column: "SecondSubclassId",
                principalTable: "SecondSubclasses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Societies_SecondSubclasses_SecondSubclassId",
                table: "Societies");

            migrationBuilder.AlterColumn<Guid>(
                name: "SecondSubclassId",
                table: "Societies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Societies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LicenseEndDate",
                table: "Societies",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "ProviderContactDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Societies_SecondSubclasses_SecondSubclassId",
                table: "Societies",
                column: "SecondSubclassId",
                principalTable: "SecondSubclasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
