using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterstes_InterestsList_InterestsListId",
                table: "UserInterstes");

            migrationBuilder.AlterColumn<int>(
                name: "InterestsListId",
                table: "UserInterstes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "UserInterstes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserInterstes_CourseId",
                table: "UserInterstes",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterstes_Course_CourseId",
                table: "UserInterstes",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterstes_InterestsList_InterestsListId",
                table: "UserInterstes",
                column: "InterestsListId",
                principalTable: "InterestsList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterstes_Course_CourseId",
                table: "UserInterstes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterstes_InterestsList_InterestsListId",
                table: "UserInterstes");

            migrationBuilder.DropIndex(
                name: "IX_UserInterstes_CourseId",
                table: "UserInterstes");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserInterstes");

            migrationBuilder.AlterColumn<int>(
                name: "InterestsListId",
                table: "UserInterstes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterstes_InterestsList_InterestsListId",
                table: "UserInterstes",
                column: "InterestsListId",
                principalTable: "InterestsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
