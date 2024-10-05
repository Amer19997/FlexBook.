using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlexBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterestsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LookUpStatus = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                    table.ForeignKey(
                        name: "FK_University_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LookUpStatus = table.Column<int>(type: "int", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculty_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DiscriptionAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DiscriptionEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LookUpStatus = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastModifiedStatus = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisterAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsSuperAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInterstes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterestsListId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterstes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInterstes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterstes_InterestsList_InterestsListId",
                        column: x => x.InterestsListId,
                        principalTable: "InterestsList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserInterstes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "IsActive", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("0c80243b-c850-49a8-92b5-deb74c3af7e1"), false, "الموضوع الأول", "Topic 1" },
                    { new Guid("1a11508a-d9d4-4b2f-a00d-f83cfd7fbd95"), false, "الموضوع الثاني", "Topic 2" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "NameAr", "NameEn", "TopicId" },
                values: new object[,]
                {
                    { new Guid("1e2d8f57-ba8f-41f9-8e34-2f4872460da6"), false, "الفئة الثانية", "Category 2", new Guid("1a11508a-d9d4-4b2f-a00d-f83cfd7fbd95") },
                    { new Guid("6e659c52-b027-4e77-9b51-d08401674b87"), false, "الفئة الأولى", "Category 1", new Guid("0c80243b-c850-49a8-92b5-deb74c3af7e1") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CoverPhoto", "DiscriptionAr", "DiscriptionEn", "IsActive", "NameAr", "NameEn", "TopicId" },
                values: new object[,]
                {
                    { new Guid("89b6a553-47fc-472f-8ba9-8ad1db96de56"), new Guid("6e659c52-b027-4e77-9b51-d08401674b87"), "cover1.jpg", "وصف الدورة الأولى", "Description of Course 1", false, "الدورة الأولى", "Course 1", new Guid("0c80243b-c850-49a8-92b5-deb74c3af7e1") },
                    { new Guid("d9c269e4-fcef-4707-8da8-14338c723921"), new Guid("1e2d8f57-ba8f-41f9-8e34-2f4872460da6"), "cover2.jpg", "وصف الدورة الثانية", "Description of Course 2", false, "الدورة الثانية", "Course 2", new Guid("1a11508a-d9d4-4b2f-a00d-f83cfd7fbd95") }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "IsActive", "TitleAr", "TitleEn" },
                values: new object[,]
                {
                    { new Guid("1f0900ad-6f47-48b4-be40-355952e61f9f"), new Guid("89b6a553-47fc-472f-8ba9-8ad1db96de56"), false, "القسم الأول", "Section 1" },
                    { new Guid("9e241f2d-8b33-4368-9c89-fa8c2bb57433"), new Guid("d9c269e4-fcef-4707-8da8-14338c723921"), false, "القسم الثاني", "Section 2" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ContentType", "FileUrl", "IsActive", "NameAr", "NameEn", "SectionId" },
                values: new object[,]
                {
                    { new Guid("2d688e72-4d72-4782-a6fc-f8bf5d0a9dbb"), "Video", "https://example.com/video1.mp4", false, "الدرس الأول", "Lesson 1", new Guid("1f0900ad-6f47-48b4-be40-355952e61f9f") },
                    { new Guid("873d0392-0f27-4a86-bafe-f01937c5a3de"), "Video", "https://example.com/video3.mp4", false, "الدرس الثالث", "Lesson 3", new Guid("9e241f2d-8b33-4368-9c89-fa8c2bb57433") },
                    { new Guid("fd2885e0-3bb0-4655-8860-955cd05f36c6"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني", "Lesson 2", new Guid("1f0900ad-6f47-48b4-be40-355952e61f9f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TopicId",
                table: "Categories",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TopicId",
                table: "Courses",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_UniversityId",
                table: "Faculty",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SectionId",
                table: "Lessons",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_University_CountryId",
                table: "University",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterstes_CourseId",
                table: "UserInterstes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterstes_InterestsListId",
                table: "UserInterstes",
                column: "InterestsListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterstes_UserId",
                table: "UserInterstes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultyId",
                table: "Users",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversityId",
                table: "Users",
                column: "UniversityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "UserInterstes");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "InterestsList");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
