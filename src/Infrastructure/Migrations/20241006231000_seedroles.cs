using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlexBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "IsActive", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, false, "الولايات المتحدة", "United States" },
                    { 2, false, "المملكة المتحدة", "United Kingdom" },
                    { 3, false, "كندا", "Canada" },
                    { 4, false, "أستراليا", "Australia" },
                    { 5, false, "الهند", "India" },
                    { 6, false, "ألمانيا", "Germany" },
                    { 7, false, "البرازيل", "Brazil" },
                    { 8, false, "اليابان", "Japan" },
                    { 9, false, "فرنسا", "France" },
                    { 10, false, "الإمارات العربية المتحدة", "United Arab Emirates" }
                });

            migrationBuilder.InsertData(
                table: "InterestsList",
                columns: new[] { "Id", "IsActive", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, false, "الذكاء الاصطناعي", "Artificial Intelligence" },
                    { 2, false, "تطوير الويب", "Web Development" },
                    { 3, false, "تحليل البيانات", "Data Analysis" },
                    { 4, false, "تعلم الآلة", "Machine Learning" },
                    { 5, false, "الأمن السيبراني", "Cyber Security" },
                    { 6, false, "إدارة الأعمال", "Business Management" },
                    { 7, false, "البرمجة", "Programming" },
                    { 8, false, "الفيزياء", "Physics" },
                    { 9, false, "الهندسة المدنية", "Civil Engineering" },
                    { 10, false, "التصميم الجرافيكي", "Graphic Design" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name", "Resource" },
                values: new object[,]
                {
                    { new Guid("149f3f36-e15b-4b6e-b60e-04df4879e86b"), "Delete", "Books" },
                    { new Guid("263dd1e4-a4ed-49c6-bc44-70756c3bf72e"), "Edit", "Books" },
                    { new Guid("778ca486-55a7-4318-aed3-4212b04f9864"), "Create", "Books" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("472f5d43-3fa0-4520-b9ec-bb1f71057159"), "Manager" },
                    { new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d"), "Admin" },
                    { new Guid("d5237557-95cd-48d4-98d7-ba9ea24e20f3"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "IsActive", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("22660d27-b55d-494b-9a48-499e9253ece7"), false, "الذكاء الاصطناعي", "Artificial Intelligence" },
                    { new Guid("25815a39-2d62-437f-97df-8e94f0bad870"), false, "الأمن السيبراني", "Cyber Security" },
                    { new Guid("3b100d6a-e395-44cc-a1df-05eb30075486"), false, "تحليل البيانات", "Data Analysis" },
                    { new Guid("409902a4-1543-4075-b409-e4df8987340d"), false, "العلوم الفيزيائية", "Physical Sciences" },
                    { new Guid("5498f95f-2125-40e9-ac3e-4b663ec1f3ad"), false, "الهندسة الكهربائية", "Electrical Engineering" },
                    { new Guid("6e97b85d-73ad-46f4-afff-d523507fb41e"), false, "الهندسة الميكانيكية", "Mechanical Engineering" },
                    { new Guid("a1c79a07-d2bd-41e9-a59d-1f36a44d9328"), false, "الهندسة المدنية", "Civil Engineering" },
                    { new Guid("ab9a5150-7141-45ca-b46d-20aad6f08f99"), false, "التعليم الإلكتروني", "E-Learning" },
                    { new Guid("bb055054-4dce-4a1c-ac58-c8a0fd2b7408"), false, "تطوير البرمجيات", "Software Development" },
                    { new Guid("f70ff1d6-5feb-44ab-9287-9873b20dcbea"), false, "التسويق الرقمي", "Digital Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "NameAr", "NameEn", "TopicId" },
                values: new object[,]
                {
                    { new Guid("197ebb1e-56b4-4f07-809c-538da1906582"), false, "ذكاء اصطناعي", "Artificial Intelligence", new Guid("22660d27-b55d-494b-9a48-499e9253ece7") },
                    { new Guid("2a2f5a02-1d93-445e-8d7f-cd335e21b367"), false, "هندسة كهربائية", "Electrical Engineering", new Guid("5498f95f-2125-40e9-ac3e-4b663ec1f3ad") },
                    { new Guid("2b4a8ede-f43e-42cb-a620-688154f117b6"), false, "تعليم إلكتروني", "E-Learning", new Guid("ab9a5150-7141-45ca-b46d-20aad6f08f99") },
                    { new Guid("3dfec3e8-6266-4c3f-8787-1c0e60cce130"), false, "تحليل البيانات", "Data Analysis", new Guid("3b100d6a-e395-44cc-a1df-05eb30075486") },
                    { new Guid("46479c8b-3542-4eed-a1f5-1b643d41c48d"), false, "هندسة ميكانيكية", "Mechanical Engineering", new Guid("6e97b85d-73ad-46f4-afff-d523507fb41e") },
                    { new Guid("635ec97e-5302-4666-9055-3d975044ad3a"), false, "هندسة مدنية", "Civil Engineering", new Guid("a1c79a07-d2bd-41e9-a59d-1f36a44d9328") },
                    { new Guid("6af6c12a-8daa-4ca1-9f2b-a9dc66b335a4"), false, "أمن سيبراني", "Cyber Security", new Guid("25815a39-2d62-437f-97df-8e94f0bad870") },
                    { new Guid("875c706b-ba8d-40bb-bac5-c5dfa6558244"), false, "علوم فيزيائية", "Physical Sciences", new Guid("409902a4-1543-4075-b409-e4df8987340d") },
                    { new Guid("9722e320-a60d-4c9d-9b52-8060d6a95a17"), false, "تسويق رقمي", "Digital Marketing", new Guid("f70ff1d6-5feb-44ab-9287-9873b20dcbea") },
                    { new Guid("d0434c1a-7d66-4536-897b-e0e3e47a5829"), false, "برمجة", "Programming", new Guid("bb055054-4dce-4a1c-ac58-c8a0fd2b7408") }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("263dd1e4-a4ed-49c6-bc44-70756c3bf72e"), new Guid("472f5d43-3fa0-4520-b9ec-bb1f71057159") },
                    { new Guid("778ca486-55a7-4318-aed3-4212b04f9864"), new Guid("472f5d43-3fa0-4520-b9ec-bb1f71057159") },
                    { new Guid("149f3f36-e15b-4b6e-b60e-04df4879e86b"), new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d") },
                    { new Guid("263dd1e4-a4ed-49c6-bc44-70756c3bf72e"), new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d") },
                    { new Guid("778ca486-55a7-4318-aed3-4212b04f9864"), new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d") }
                });

            migrationBuilder.InsertData(
                table: "University",
                columns: new[] { "Id", "CountryId", "IsActive", "LookUpStatus", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("0959c1a0-f522-4f71-a2c9-9a7837d661c8"), 2, false, 2, "جامعة المملكة المتحدة", "University of United Kingdom" },
                    { new Guid("20bbdc4e-55ec-45b8-8cb3-e6fd13a1cf93"), 10, false, 2, "جامعة الإمارات العربية المتحدة", "University of United Arab Emirates" },
                    { new Guid("2a13463e-5ebd-4288-9c96-6fd676a79e99"), 6, false, 2, "جامعة ألمانيا", "University of Germany" },
                    { new Guid("3b34131c-7f07-4a81-bea8-b42215bd45c1"), 1, false, 2, "جامعة الولايات المتحدة", "University of United States" },
                    { new Guid("5a97ef33-c59e-40d5-af0d-14a7c5b4dc5d"), 8, false, 2, "جامعة اليابان", "University of Japan" },
                    { new Guid("85350a49-62a3-4409-bc13-89e5a5ff976a"), 4, false, 2, "جامعة أستراليا", "University of Australia" },
                    { new Guid("b899531d-52ed-4666-9b69-bb71a84bb44e"), 3, false, 2, "جامعة كندا", "University of Canada" },
                    { new Guid("b9c5f8b6-64d4-4f31-a123-6ac65b9b37b4"), 9, false, 2, "جامعة فرنسا", "University of France" },
                    { new Guid("c6cef3a2-a3b6-4847-ac05-20bb94abdbde"), 7, false, 2, "جامعة البرازيل", "University of Brazil" },
                    { new Guid("d4db78a5-e300-42d6-92fd-a3f1470a9cd0"), 5, false, 2, "جامعة الهند", "University of India" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AcademicYear", "CountryId", "Created", "CreatedBy", "DepartmentId", "Email", "FacultyId", "FirstName", "LastModified", "LastModifiedBy", "LastModifiedStatus", "LastName", "MobileNumber", "Password", "RegisterAt", "RoleId", "SpecializationId", "Status", "StudyLevel", "UniversityId", "UserType" },
                values: new object[,]
                {
                    { new Guid("0b2f8155-a3bd-4de7-94a6-573ff703b82f"), null, 1, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4737), null, null, "user10@example.com", null, "User10", null, null, null, "LastName10", "12345678910", "password10", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4732), new TimeSpan(0, 3, 0, 0, 0)), new Guid("d5237557-95cd-48d4-98d7-ba9ea24e20f3"), null, 2, null, null, 1 },
                    { new Guid("3763cc02-ae69-4d91-8f7d-b4396eef6866"), null, 2, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4590), null, null, "user1@example.com", null, "User1", null, null, null, "LastName1", "1234567891", "password1", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4523), new TimeSpan(0, 3, 0, 0, 0)), new Guid("d5237557-95cd-48d4-98d7-ba9ea24e20f3"), null, 2, null, null, 1 },
                    { new Guid("5c475ed1-3980-4323-81c7-055a08de3a18"), null, 7, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4693), null, null, "user6@example.com", null, "User6", null, null, null, "LastName6", "1234567896", "password6", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4649), new TimeSpan(0, 3, 0, 0, 0)), new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d"), null, 2, null, null, 1 },
                    { new Guid("679cb9c1-2f8b-460d-a245-cf65d6048fef"), null, 3, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4616), null, null, "user2@example.com", null, "User2", null, null, null, "LastName2", "1234567892", "password2", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4612), new TimeSpan(0, 3, 0, 0, 0)), new Guid("472f5d43-3fa0-4520-b9ec-bb1f71057159"), null, 2, null, null, 1 },
                    { new Guid("6861427e-b790-457f-ad6a-8ce1ce21b27e"), null, 4, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4625), null, null, "user3@example.com", null, "User3", null, null, null, "LastName3", "1234567893", "password3", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4621), new TimeSpan(0, 3, 0, 0, 0)), new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d"), null, 2, null, null, 1 },
                    { new Guid("b1ebe749-a80c-475e-a503-c217e77496be"), null, 5, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4634), null, null, "user4@example.com", null, "User4", null, null, null, "LastName4", "1234567894", "password4", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 3, 0, 0, 0)), new Guid("d5237557-95cd-48d4-98d7-ba9ea24e20f3"), null, 2, null, null, 1 },
                    { new Guid("c4b1a857-45ff-4f28-a81b-c5d952a19f1f"), null, 9, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4716), null, null, "user8@example.com", null, "User8", null, null, null, "LastName8", "1234567898", "password8", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 3, 0, 0, 0)), new Guid("472f5d43-3fa0-4520-b9ec-bb1f71057159"), null, 2, null, null, 1 },
                    { new Guid("d54b92a3-540a-4b6f-8985-12791ee63263"), null, 10, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4726), null, null, "user9@example.com", null, "User9", null, null, null, "LastName9", "1234567899", "password9", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4722), new TimeSpan(0, 3, 0, 0, 0)), new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d"), null, 2, null, null, 1 },
                    { new Guid("d5ab757d-796b-4de6-ad84-34711bd86c5c"), null, 8, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4704), null, null, "user7@example.com", null, "User7", null, null, null, "LastName7", "1234567897", "password7", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 3, 0, 0, 0)), new Guid("d5237557-95cd-48d4-98d7-ba9ea24e20f3"), null, 2, null, null, 1 },
                    { new Guid("f9b39dda-34a0-4466-96ba-0597cb45d3bf"), null, 6, new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Local).AddTicks(4642), null, null, "user5@example.com", null, "User5", null, null, null, "LastName5", "1234567895", "password5", new DateTimeOffset(new DateTime(2024, 10, 7, 2, 10, 0, 45, DateTimeKind.Unspecified).AddTicks(4639), new TimeSpan(0, 3, 0, 0, 0)), new Guid("472f5d43-3fa0-4520-b9ec-bb1f71057159"), null, 2, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CoverPhoto", "DiscriptionAr", "DiscriptionEn", "IsActive", "NameAr", "NameEn", "TopicId" },
                values: new object[,]
                {
                    { new Guid("5cc91fe4-bad4-4a14-b6cf-ade12e873e85"), new Guid("46479c8b-3542-4eed-a1f5-1b643d41c48d"), "mechanical_engineering.jpg", "دورة تعلم مبادئ الهندسة الميكانيكية", "Learn the principles of mechanical engineering", false, "مبادئ الهندسة الميكانيكية", "Mechanical Engineering Principles", new Guid("6e97b85d-73ad-46f4-afff-d523507fb41e") },
                    { new Guid("60b3f428-1327-4fb2-be86-e2092b562d53"), new Guid("2b4a8ede-f43e-42cb-a620-688154f117b6"), "e_learning.jpg", "دورة تعلم مبادئ التعليم الإلكتروني", "Introduction to e-learning", false, "مقدمة في التعليم الإلكتروني", "Intro to E-Learning", new Guid("ab9a5150-7141-45ca-b46d-20aad6f08f99") },
                    { new Guid("72686a55-4931-48cf-b9ab-b52d205c8807"), new Guid("2a2f5a02-1d93-445e-8d7f-cd335e21b367"), "electrical_engineering.jpg", "دورة تعلم أساسيات الهندسة الكهربائية", "Learn the basics of electrical engineering", false, "أساسيات الهندسة الكهربائية", "Electrical Engineering Basics", new Guid("5498f95f-2125-40e9-ac3e-4b663ec1f3ad") },
                    { new Guid("739dfa86-391e-461f-b2a0-157f2cb911e7"), new Guid("9722e320-a60d-4c9d-9b52-8060d6a95a17"), "digital_marketing.jpg", "دورة تعلم أساسيات التسويق الرقمي", "Learn the basics of digital marketing", false, "أساسيات التسويق الرقمي", "Digital Marketing Basics", new Guid("f70ff1d6-5feb-44ab-9287-9873b20dcbea") },
                    { new Guid("91094748-1873-4547-b0eb-f9058858ab35"), new Guid("197ebb1e-56b4-4f07-809c-538da1906582"), "ai_intro.jpg", "دورة مقدمة في الذكاء الاصطناعي", "Introduction to Artificial Intelligence", false, "مقدمة في الذكاء الاصطناعي", "Intro to Artificial Intelligence", new Guid("22660d27-b55d-494b-9a48-499e9253ece7") },
                    { new Guid("9b057b08-6ea0-4436-9264-4eddd09e42d7"), new Guid("635ec97e-5302-4666-9055-3d975044ad3a"), "civil_engineering.jpg", "دورة تعلم الهندسة المدنية المتقدمة", "Learn advanced civil engineering", false, "الهندسة المدنية المتقدمة", "Advanced Civil Engineering", new Guid("a1c79a07-d2bd-41e9-a59d-1f36a44d9328") },
                    { new Guid("a1e1e039-1f5d-44a1-9098-52b06744a0cf"), new Guid("3dfec3e8-6266-4c3f-8787-1c0e60cce130"), "data_analysis.jpg", "دورة تعلم تحليل البيانات المتقدم", "Learn advanced data analysis", false, "تحليل البيانات المتقدم", "Advanced Data Analysis", new Guid("3b100d6a-e395-44cc-a1df-05eb30075486") },
                    { new Guid("dde02ce6-99c3-445c-b8ba-e313dbc89efc"), new Guid("6af6c12a-8daa-4ca1-9f2b-a9dc66b335a4"), "cyber_security.jpg", "دورة تعلم مبادئ الأمن السيبراني", "Learn the fundamentals of cyber security", false, "مبادئ الأمن السيبراني", "Cyber Security Fundamentals", new Guid("25815a39-2d62-437f-97df-8e94f0bad870") },
                    { new Guid("e504354f-16b5-44f5-9a70-9b54b2c53876"), new Guid("d0434c1a-7d66-4536-897b-e0e3e47a5829"), "programming_basics.jpg", "دورة تعلم أساسيات البرمجة", "Learn the basics of programming", false, "أساسيات البرمجة", "Programming Basics", new Guid("bb055054-4dce-4a1c-ac58-c8a0fd2b7408") },
                    { new Guid("f4e28887-491a-4c29-bcbf-2cfb49b35f12"), new Guid("875c706b-ba8d-40bb-bac5-c5dfa6558244"), "physics_basics.jpg", "دورة تعلم أساسيات الفيزياء", "Learn the basics of physics", false, "أساسيات الفيزياء", "Physics Basics", new Guid("409902a4-1543-4075-b409-e4df8987340d") }
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "IsActive", "LookUpStatus", "NameAr", "NameEn", "UniversityId" },
                values: new object[,]
                {
                    { new Guid("08660b0f-a4db-40e6-9813-be1f31102012"), false, 2, "كلية العلوم في جامعة الإمارات العربية المتحدة", "Faculty of Science in University of United Arab Emirates", new Guid("20bbdc4e-55ec-45b8-8cb3-e6fd13a1cf93") },
                    { new Guid("0daf3353-5b9e-45c7-bdb1-76f8b2d7de68"), false, 2, "كلية العلوم في جامعة أستراليا", "Faculty of Science in University of Australia", new Guid("85350a49-62a3-4409-bc13-89e5a5ff976a") },
                    { new Guid("19e99943-84a7-4f5d-a678-3bf1a39f25cf"), false, 2, "كلية العلوم في جامعة الهند", "Faculty of Science in University of India", new Guid("d4db78a5-e300-42d6-92fd-a3f1470a9cd0") },
                    { new Guid("1ebc4790-2b92-4b1e-986d-789596d251c9"), false, 2, "كلية الهندسة في جامعة المملكة المتحدة", "Faculty of Engineering in University of United Kingdom", new Guid("0959c1a0-f522-4f71-a2c9-9a7837d661c8") },
                    { new Guid("479aea90-8844-4610-840c-cec703a0ca02"), false, 2, "كلية العلوم في جامعة ألمانيا", "Faculty of Science in University of Germany", new Guid("2a13463e-5ebd-4288-9c96-6fd676a79e99") },
                    { new Guid("4ad71fb4-6b5f-462a-bd8c-bfef326443ce"), false, 2, "كلية العلوم في جامعة فرنسا", "Faculty of Science in University of France", new Guid("b9c5f8b6-64d4-4f31-a123-6ac65b9b37b4") },
                    { new Guid("72ba785f-7bca-4de2-ad88-495bb4582750"), false, 2, "كلية العلوم في جامعة اليابان", "Faculty of Science in University of Japan", new Guid("5a97ef33-c59e-40d5-af0d-14a7c5b4dc5d") },
                    { new Guid("77cf0ec6-ec28-4b02-b1bd-d0f8dfc7da32"), false, 2, "كلية الهندسة في جامعة أستراليا", "Faculty of Engineering in University of Australia", new Guid("85350a49-62a3-4409-bc13-89e5a5ff976a") },
                    { new Guid("88fccafd-d8bc-43f9-a2f6-757004fbd049"), false, 2, "كلية العلوم في جامعة كندا", "Faculty of Science in University of Canada", new Guid("b899531d-52ed-4666-9b69-bb71a84bb44e") },
                    { new Guid("93fc72ed-065e-4c8e-a333-179e8cf4db84"), false, 2, "كلية الهندسة في جامعة اليابان", "Faculty of Engineering in University of Japan", new Guid("5a97ef33-c59e-40d5-af0d-14a7c5b4dc5d") },
                    { new Guid("9c1ca49c-91e2-4fa2-be25-3acad4ecba75"), false, 2, "كلية الهندسة في جامعة الإمارات العربية المتحدة", "Faculty of Engineering in University of United Arab Emirates", new Guid("20bbdc4e-55ec-45b8-8cb3-e6fd13a1cf93") },
                    { new Guid("ac649b42-34ad-4908-aadb-19e80fcd993e"), false, 2, "كلية الهندسة في جامعة فرنسا", "Faculty of Engineering in University of France", new Guid("b9c5f8b6-64d4-4f31-a123-6ac65b9b37b4") },
                    { new Guid("b0e542ad-595d-4d76-9da1-208e0e74334a"), false, 2, "كلية الهندسة في جامعة الولايات المتحدة", "Faculty of Engineering in University of United States", new Guid("3b34131c-7f07-4a81-bea8-b42215bd45c1") },
                    { new Guid("c744cfeb-e39a-49fc-9efb-0a6334832519"), false, 2, "كلية العلوم في جامعة المملكة المتحدة", "Faculty of Science in University of United Kingdom", new Guid("0959c1a0-f522-4f71-a2c9-9a7837d661c8") },
                    { new Guid("cab6047f-5dc4-41aa-a566-df3985525f66"), false, 2, "كلية العلوم في جامعة الولايات المتحدة", "Faculty of Science in University of United States", new Guid("3b34131c-7f07-4a81-bea8-b42215bd45c1") },
                    { new Guid("d3354784-0934-489b-b41c-cb1e0d6cf992"), false, 2, "كلية الهندسة في جامعة ألمانيا", "Faculty of Engineering in University of Germany", new Guid("2a13463e-5ebd-4288-9c96-6fd676a79e99") },
                    { new Guid("e7c2d7e3-e0f9-4f7e-96a9-dc3e34524c9d"), false, 2, "كلية العلوم في جامعة البرازيل", "Faculty of Science in University of Brazil", new Guid("c6cef3a2-a3b6-4847-ac05-20bb94abdbde") },
                    { new Guid("ed906c6f-fb95-4052-afcc-1fe13aef4abb"), false, 2, "كلية الهندسة في جامعة كندا", "Faculty of Engineering in University of Canada", new Guid("b899531d-52ed-4666-9b69-bb71a84bb44e") },
                    { new Guid("ee86f84b-6238-4324-8148-2a8870068c5d"), false, 2, "كلية الهندسة في جامعة البرازيل", "Faculty of Engineering in University of Brazil", new Guid("c6cef3a2-a3b6-4847-ac05-20bb94abdbde") },
                    { new Guid("f295fcd2-5ecc-4e5f-8c99-4f21d1c438aa"), false, 2, "كلية الهندسة في جامعة الهند", "Faculty of Engineering in University of India", new Guid("d4db78a5-e300-42d6-92fd-a3f1470a9cd0") }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "FacultyId", "IsActive", "LookUpStatus", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("0a291d4c-396c-4fa1-87f0-52dd1a34846b"), new Guid("72ba785f-7bca-4de2-ad88-495bb4582750"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة اليابان", "Department of Physics in Faculty of Science in University of Japan" },
                    { new Guid("17973669-f435-44ec-bf78-6ea35a6808c0"), new Guid("ed906c6f-fb95-4052-afcc-1fe13aef4abb"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة كندا", "Department of Physics in Faculty of Engineering in University of Canada" },
                    { new Guid("2a9534e6-ff65-429f-bea4-ce8a4e82dd08"), new Guid("ed906c6f-fb95-4052-afcc-1fe13aef4abb"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة كندا", "Department of Computer Science in Faculty of Engineering in University of Canada" },
                    { new Guid("3033d647-ef48-4659-9f44-72cb78c16619"), new Guid("f295fcd2-5ecc-4e5f-8c99-4f21d1c438aa"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة الهند", "Department of Physics in Faculty of Engineering in University of India" },
                    { new Guid("31193a54-e372-4057-b3c5-24791ee2ee53"), new Guid("e7c2d7e3-e0f9-4f7e-96a9-dc3e34524c9d"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة البرازيل", "Department of Computer Science in Faculty of Science in University of Brazil" },
                    { new Guid("3147b17d-6c8d-4574-a168-16031779a714"), new Guid("479aea90-8844-4610-840c-cec703a0ca02"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة ألمانيا", "Department of Physics in Faculty of Science in University of Germany" },
                    { new Guid("33ca39e0-f8c7-4041-83ae-e12aec9143d8"), new Guid("479aea90-8844-4610-840c-cec703a0ca02"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة ألمانيا", "Department of Computer Science in Faculty of Science in University of Germany" },
                    { new Guid("38b6160b-7a49-4b93-89cf-fe85a3627a04"), new Guid("08660b0f-a4db-40e6-9813-be1f31102012"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة الإمارات العربية المتحدة", "Department of Computer Science in Faculty of Science in University of United Arab Emirates" },
                    { new Guid("47958b8e-19bc-48b1-883a-c1118ea9b1ba"), new Guid("b0e542ad-595d-4d76-9da1-208e0e74334a"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة الولايات المتحدة", "Department of Computer Science in Faculty of Engineering in University of United States" },
                    { new Guid("4e9ccb74-c4ec-4144-8344-e243f8df8e2a"), new Guid("d3354784-0934-489b-b41c-cb1e0d6cf992"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة ألمانيا", "Department of Computer Science in Faculty of Engineering in University of Germany" },
                    { new Guid("54939d4c-ef6d-4ca5-b74f-6c05f5941b0a"), new Guid("9c1ca49c-91e2-4fa2-be25-3acad4ecba75"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة الإمارات العربية المتحدة", "Department of Computer Science in Faculty of Engineering in University of United Arab Emirates" },
                    { new Guid("5ba67242-68ca-484f-9d39-e9f40816c3b8"), new Guid("77cf0ec6-ec28-4b02-b1bd-d0f8dfc7da32"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة أستراليا", "Department of Computer Science in Faculty of Engineering in University of Australia" },
                    { new Guid("5bdb0d03-d944-4cbd-99d4-75651ca5f8e5"), new Guid("1ebc4790-2b92-4b1e-986d-789596d251c9"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة المملكة المتحدة", "Department of Computer Science in Faculty of Engineering in University of United Kingdom" },
                    { new Guid("6edf384f-267e-464e-b93c-56d36b73e2f0"), new Guid("cab6047f-5dc4-41aa-a566-df3985525f66"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة الولايات المتحدة", "Department of Computer Science in Faculty of Science in University of United States" },
                    { new Guid("6f587703-4146-44c9-8cd6-94c4ce49b445"), new Guid("0daf3353-5b9e-45c7-bdb1-76f8b2d7de68"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة أستراليا", "Department of Computer Science in Faculty of Science in University of Australia" },
                    { new Guid("7008ce4e-45f6-4d8c-9e46-4174c40a406a"), new Guid("d3354784-0934-489b-b41c-cb1e0d6cf992"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة ألمانيا", "Department of Physics in Faculty of Engineering in University of Germany" },
                    { new Guid("73fa375f-21fc-4e35-90dc-5b17f78f0bbb"), new Guid("f295fcd2-5ecc-4e5f-8c99-4f21d1c438aa"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة الهند", "Department of Computer Science in Faculty of Engineering in University of India" },
                    { new Guid("7adde1f4-966e-44ea-aff9-aaccfa779524"), new Guid("72ba785f-7bca-4de2-ad88-495bb4582750"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة اليابان", "Department of Computer Science in Faculty of Science in University of Japan" },
                    { new Guid("80580be3-5a6e-4622-8d09-7ecebbac7654"), new Guid("88fccafd-d8bc-43f9-a2f6-757004fbd049"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة كندا", "Department of Computer Science in Faculty of Science in University of Canada" },
                    { new Guid("81015447-d5c5-44c8-afa1-328221c7e16b"), new Guid("ee86f84b-6238-4324-8148-2a8870068c5d"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة البرازيل", "Department of Computer Science in Faculty of Engineering in University of Brazil" },
                    { new Guid("85f71c3a-885c-4155-ab87-777e52741295"), new Guid("19e99943-84a7-4f5d-a678-3bf1a39f25cf"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة الهند", "Department of Physics in Faculty of Science in University of India" },
                    { new Guid("89d426aa-5d1b-4f37-98d6-62270e7b6777"), new Guid("93fc72ed-065e-4c8e-a333-179e8cf4db84"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة اليابان", "Department of Physics in Faculty of Engineering in University of Japan" },
                    { new Guid("8cdf5524-6c92-4a5b-a866-86ea7a007a1c"), new Guid("b0e542ad-595d-4d76-9da1-208e0e74334a"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة الولايات المتحدة", "Department of Physics in Faculty of Engineering in University of United States" },
                    { new Guid("90f9aca4-3544-4021-8a5a-24a8b8071c8c"), new Guid("4ad71fb4-6b5f-462a-bd8c-bfef326443ce"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة فرنسا", "Department of Computer Science in Faculty of Science in University of France" },
                    { new Guid("92733b67-ed72-46c7-b9c2-abf5430d0839"), new Guid("ac649b42-34ad-4908-aadb-19e80fcd993e"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة فرنسا", "Department of Physics in Faculty of Engineering in University of France" },
                    { new Guid("9d1586ce-3902-4b7a-884f-0c2d029ad0f9"), new Guid("cab6047f-5dc4-41aa-a566-df3985525f66"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة الولايات المتحدة", "Department of Physics in Faculty of Science in University of United States" },
                    { new Guid("a098aa09-9d51-4c9d-94e8-ee15dd3e5e29"), new Guid("08660b0f-a4db-40e6-9813-be1f31102012"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة الإمارات العربية المتحدة", "Department of Physics in Faculty of Science in University of United Arab Emirates" },
                    { new Guid("a47ea557-9bf1-4034-9eaf-916038451ee2"), new Guid("c744cfeb-e39a-49fc-9efb-0a6334832519"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة المملكة المتحدة", "Department of Physics in Faculty of Science in University of United Kingdom" },
                    { new Guid("ad29f6af-1b2b-4a89-9622-3b3244833208"), new Guid("4ad71fb4-6b5f-462a-bd8c-bfef326443ce"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة فرنسا", "Department of Physics in Faculty of Science in University of France" },
                    { new Guid("c593e849-e78a-44bc-9ac4-84e6dd7bea4d"), new Guid("c744cfeb-e39a-49fc-9efb-0a6334832519"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة المملكة المتحدة", "Department of Computer Science in Faculty of Science in University of United Kingdom" },
                    { new Guid("c74e902e-664b-448b-b85a-99f24c60e64e"), new Guid("ee86f84b-6238-4324-8148-2a8870068c5d"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة البرازيل", "Department of Physics in Faculty of Engineering in University of Brazil" },
                    { new Guid("c82b40b3-6483-4955-879f-20e08ef69a35"), new Guid("0daf3353-5b9e-45c7-bdb1-76f8b2d7de68"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة أستراليا", "Department of Physics in Faculty of Science in University of Australia" },
                    { new Guid("d324cd03-2b03-471c-bbc8-a54909384001"), new Guid("ac649b42-34ad-4908-aadb-19e80fcd993e"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة فرنسا", "Department of Computer Science in Faculty of Engineering in University of France" },
                    { new Guid("d3f7e6b5-d402-43bb-a1f3-d05e811a9673"), new Guid("e7c2d7e3-e0f9-4f7e-96a9-dc3e34524c9d"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة البرازيل", "Department of Physics in Faculty of Science in University of Brazil" },
                    { new Guid("d6c4c48a-8b46-4983-ac61-c69a181cd2eb"), new Guid("19e99943-84a7-4f5d-a678-3bf1a39f25cf"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة الهند", "Department of Computer Science in Faculty of Science in University of India" },
                    { new Guid("f325d231-1877-434f-8228-659b033be139"), new Guid("1ebc4790-2b92-4b1e-986d-789596d251c9"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة المملكة المتحدة", "Department of Physics in Faculty of Engineering in University of United Kingdom" },
                    { new Guid("f3798180-edf2-4d1b-add3-743ab6d82f32"), new Guid("88fccafd-d8bc-43f9-a2f6-757004fbd049"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة كندا", "Department of Physics in Faculty of Science in University of Canada" },
                    { new Guid("f59b6035-ab82-4f83-bb79-0f16663e3441"), new Guid("77cf0ec6-ec28-4b02-b1bd-d0f8dfc7da32"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة أستراليا", "Department of Physics in Faculty of Engineering in University of Australia" },
                    { new Guid("fd0dacab-2e28-4e6c-9108-85a89b145aef"), new Guid("93fc72ed-065e-4c8e-a333-179e8cf4db84"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة اليابان", "Department of Computer Science in Faculty of Engineering in University of Japan" },
                    { new Guid("ff3fef0b-2242-4469-aa61-c08dd474dbf3"), new Guid("9c1ca49c-91e2-4fa2-be25-3acad4ecba75"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة الإمارات العربية المتحدة", "Department of Physics in Faculty of Engineering in University of United Arab Emirates" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "IsActive", "TitleAr", "TitleEn" },
                values: new object[,]
                {
                    { new Guid("1794a715-51ca-4753-a849-2afec386f464"), new Guid("9b057b08-6ea0-4436-9264-4eddd09e42d7"), false, "القسم الأول في الهندسة المدنية المتقدمة", "First section in Advanced Civil Engineering" },
                    { new Guid("1ea43531-f953-45e8-8f54-b82e65a4bf6e"), new Guid("739dfa86-391e-461f-b2a0-157f2cb911e7"), false, "القسم الأول في أساسيات التسويق الرقمي", "First section in Digital Marketing Basics" },
                    { new Guid("2164036e-79b6-4bea-93c4-2c69aabc8be3"), new Guid("91094748-1873-4547-b0eb-f9058858ab35"), false, "القسم الأول في مقدمة في الذكاء الاصطناعي", "First section in Intro to Artificial Intelligence" },
                    { new Guid("3651861d-e1a5-4f7b-b659-67f90dfc4ea9"), new Guid("72686a55-4931-48cf-b9ab-b52d205c8807"), false, "القسم الأول في أساسيات الهندسة الكهربائية", "First section in Electrical Engineering Basics" },
                    { new Guid("410bb0b2-48e0-4c40-a75a-3e027f47a9db"), new Guid("f4e28887-491a-4c29-bcbf-2cfb49b35f12"), false, "القسم الثاني في أساسيات الفيزياء", "Second section in Physics Basics" },
                    { new Guid("46bc47ec-15cb-4371-9fb3-2ed0dafe4ef6"), new Guid("a1e1e039-1f5d-44a1-9098-52b06744a0cf"), false, "القسم الثاني في تحليل البيانات المتقدم", "Second section in Advanced Data Analysis" },
                    { new Guid("50816fa6-7b7a-4ae7-8168-b3b48f15c8f0"), new Guid("a1e1e039-1f5d-44a1-9098-52b06744a0cf"), false, "القسم الأول في تحليل البيانات المتقدم", "First section in Advanced Data Analysis" },
                    { new Guid("5b76fbfb-56a0-4df2-8f7b-01d484b536e4"), new Guid("dde02ce6-99c3-445c-b8ba-e313dbc89efc"), false, "القسم الثاني في مبادئ الأمن السيبراني", "Second section in Cyber Security Fundamentals" },
                    { new Guid("69a10083-c6f5-4152-9a5d-56d0f3a69fc6"), new Guid("f4e28887-491a-4c29-bcbf-2cfb49b35f12"), false, "القسم الأول في أساسيات الفيزياء", "First section in Physics Basics" },
                    { new Guid("7191e2eb-7697-4e59-b644-0b554f312e97"), new Guid("60b3f428-1327-4fb2-be86-e2092b562d53"), false, "القسم الثاني في مقدمة في التعليم الإلكتروني", "Second section in Intro to E-Learning" },
                    { new Guid("727d1bb5-d343-49e5-8e09-677ec42fac13"), new Guid("72686a55-4931-48cf-b9ab-b52d205c8807"), false, "القسم الثاني في أساسيات الهندسة الكهربائية", "Second section in Electrical Engineering Basics" },
                    { new Guid("86cfdab6-4386-4dce-a410-f452041a92c5"), new Guid("9b057b08-6ea0-4436-9264-4eddd09e42d7"), false, "القسم الثاني في الهندسة المدنية المتقدمة", "Second section in Advanced Civil Engineering" },
                    { new Guid("aca40286-8d9a-4a35-a669-d9f5001096eb"), new Guid("5cc91fe4-bad4-4a14-b6cf-ade12e873e85"), false, "القسم الثاني في مبادئ الهندسة الميكانيكية", "Second section in Mechanical Engineering Principles" },
                    { new Guid("c13a86a4-2e5e-492f-9856-9df3fa2cb81a"), new Guid("5cc91fe4-bad4-4a14-b6cf-ade12e873e85"), false, "القسم الأول في مبادئ الهندسة الميكانيكية", "First section in Mechanical Engineering Principles" },
                    { new Guid("c6890e07-1117-47c4-8c00-3666c0c53b07"), new Guid("60b3f428-1327-4fb2-be86-e2092b562d53"), false, "القسم الأول في مقدمة في التعليم الإلكتروني", "First section in Intro to E-Learning" },
                    { new Guid("cbbb90ab-d91d-4dc7-b82d-a6fcc246c10d"), new Guid("dde02ce6-99c3-445c-b8ba-e313dbc89efc"), false, "القسم الأول في مبادئ الأمن السيبراني", "First section in Cyber Security Fundamentals" },
                    { new Guid("d9257731-5392-445c-be5a-dcee51240f05"), new Guid("e504354f-16b5-44f5-9a70-9b54b2c53876"), false, "القسم الثاني في أساسيات البرمجة", "Second section in Programming Basics" },
                    { new Guid("dddb525b-5ff4-4eb4-ba63-14fbe40d1410"), new Guid("91094748-1873-4547-b0eb-f9058858ab35"), false, "القسم الثاني في مقدمة في الذكاء الاصطناعي", "Second section in Intro to Artificial Intelligence" },
                    { new Guid("ebf43faf-7b3a-4f96-bf9d-0538d1a7b5fa"), new Guid("e504354f-16b5-44f5-9a70-9b54b2c53876"), false, "القسم الأول في أساسيات البرمجة", "First section in Programming Basics" },
                    { new Guid("ff6dd14d-fa23-4347-b882-85cedf0e4158"), new Guid("739dfa86-391e-461f-b2a0-157f2cb911e7"), false, "القسم الثاني في أساسيات التسويق الرقمي", "Second section in Digital Marketing Basics" }
                });

            migrationBuilder.InsertData(
                table: "UserInterstes",
                columns: new[] { "Id", "CourseId", "InterestsListId", "IsActive", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("e504354f-16b5-44f5-9a70-9b54b2c53876"), null, false, new Guid("3763cc02-ae69-4d91-8f7d-b4396eef6866") },
                    { 2, new Guid("a1e1e039-1f5d-44a1-9098-52b06744a0cf"), null, false, new Guid("679cb9c1-2f8b-460d-a245-cf65d6048fef") },
                    { 3, new Guid("91094748-1873-4547-b0eb-f9058858ab35"), null, false, new Guid("6861427e-b790-457f-ad6a-8ce1ce21b27e") },
                    { 4, new Guid("dde02ce6-99c3-445c-b8ba-e313dbc89efc"), null, false, new Guid("b1ebe749-a80c-475e-a503-c217e77496be") },
                    { 5, new Guid("60b3f428-1327-4fb2-be86-e2092b562d53"), null, false, new Guid("f9b39dda-34a0-4466-96ba-0597cb45d3bf") },
                    { 6, new Guid("739dfa86-391e-461f-b2a0-157f2cb911e7"), null, false, new Guid("5c475ed1-3980-4323-81c7-055a08de3a18") },
                    { 7, new Guid("72686a55-4931-48cf-b9ab-b52d205c8807"), null, false, new Guid("d5ab757d-796b-4de6-ad84-34711bd86c5c") },
                    { 8, new Guid("5cc91fe4-bad4-4a14-b6cf-ade12e873e85"), null, false, new Guid("c4b1a857-45ff-4f28-a81b-c5d952a19f1f") },
                    { 9, new Guid("9b057b08-6ea0-4436-9264-4eddd09e42d7"), null, false, new Guid("d54b92a3-540a-4b6f-8985-12791ee63263") },
                    { 10, new Guid("f4e28887-491a-4c29-bcbf-2cfb49b35f12"), null, false, new Guid("0b2f8155-a3bd-4de7-94a6-573ff703b82f") }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ContentType", "FileUrl", "IsActive", "NameAr", "NameEn", "SectionId" },
                values: new object[,]
                {
                    { new Guid("03dd8e2a-99cd-4e49-8c0b-9fb791a64fa9"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في الهندسة المدنية المتقدمة", "First lesson in First section in Advanced Civil Engineering", new Guid("1794a715-51ca-4753-a849-2afec386f464") },
                    { new Guid("08bfee98-434a-452e-a5d3-8fe3570c840c"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في أساسيات البرمجة", "Second lesson in First section in Programming Basics", new Guid("ebf43faf-7b3a-4f96-bf9d-0538d1a7b5fa") },
                    { new Guid("0e5065e6-f200-44f1-a0f7-2f48cd1f8952"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في مقدمة في التعليم الإلكتروني", "Second lesson in Second section in Intro to E-Learning", new Guid("7191e2eb-7697-4e59-b644-0b554f312e97") },
                    { new Guid("17a24d79-391e-4723-a1ad-337b9facdb30"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في أساسيات الهندسة الكهربائية", "First lesson in Second section in Electrical Engineering Basics", new Guid("727d1bb5-d343-49e5-8e09-677ec42fac13") },
                    { new Guid("191ab0ca-5400-44b6-90f3-8a6492da96f7"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في تحليل البيانات المتقدم", "Second lesson in Second section in Advanced Data Analysis", new Guid("46bc47ec-15cb-4371-9fb3-2ed0dafe4ef6") },
                    { new Guid("2096eff2-9b4b-4462-ab4c-1f5af86d60ad"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في مقدمة في الذكاء الاصطناعي", "Second lesson in Second section in Intro to Artificial Intelligence", new Guid("dddb525b-5ff4-4eb4-ba63-14fbe40d1410") },
                    { new Guid("2c51371a-8124-4a99-9e2c-75524e2ae11c"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في أساسيات البرمجة", "First lesson in Second section in Programming Basics", new Guid("d9257731-5392-445c-be5a-dcee51240f05") },
                    { new Guid("34d847d4-23ba-4329-b79a-b96fc119b745"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في الهندسة المدنية المتقدمة", "Second lesson in First section in Advanced Civil Engineering", new Guid("1794a715-51ca-4753-a849-2afec386f464") },
                    { new Guid("456e5fcc-4dbe-47e1-b69d-a54dc382375a"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في أساسيات التسويق الرقمي", "Second lesson in Second section in Digital Marketing Basics", new Guid("ff6dd14d-fa23-4347-b882-85cedf0e4158") },
                    { new Guid("48093142-1378-4018-8ffd-fd5890d29cc1"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في تحليل البيانات المتقدم", "First lesson in First section in Advanced Data Analysis", new Guid("50816fa6-7b7a-4ae7-8168-b3b48f15c8f0") },
                    { new Guid("4fff1b13-de22-4e3e-963a-eb279d8f4215"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في مبادئ الهندسة الميكانيكية", "First lesson in Second section in Mechanical Engineering Principles", new Guid("aca40286-8d9a-4a35-a669-d9f5001096eb") },
                    { new Guid("5b8a656c-9f60-4c4e-8457-93c826a31a4c"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في أساسيات الهندسة الكهربائية", "Second lesson in First section in Electrical Engineering Basics", new Guid("3651861d-e1a5-4f7b-b659-67f90dfc4ea9") },
                    { new Guid("5c33f7f9-9f06-4003-9c5f-21f44fd70a79"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في تحليل البيانات المتقدم", "First lesson in Second section in Advanced Data Analysis", new Guid("46bc47ec-15cb-4371-9fb3-2ed0dafe4ef6") },
                    { new Guid("5dd4f634-1a7b-4847-acfe-aed5c95b8f2a"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في تحليل البيانات المتقدم", "Second lesson in First section in Advanced Data Analysis", new Guid("50816fa6-7b7a-4ae7-8168-b3b48f15c8f0") },
                    { new Guid("61505696-df1d-4ac0-b39d-639138d8fca9"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في أساسيات التسويق الرقمي", "First lesson in Second section in Digital Marketing Basics", new Guid("ff6dd14d-fa23-4347-b882-85cedf0e4158") },
                    { new Guid("63b7d59e-c194-4bea-951c-945c52bf63e7"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في مقدمة في التعليم الإلكتروني", "First lesson in First section in Intro to E-Learning", new Guid("c6890e07-1117-47c4-8c00-3666c0c53b07") },
                    { new Guid("6aa2ee33-133b-46fc-b492-29ef07f9affd"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في مبادئ الهندسة الميكانيكية", "First lesson in First section in Mechanical Engineering Principles", new Guid("c13a86a4-2e5e-492f-9856-9df3fa2cb81a") },
                    { new Guid("7088e7f9-2922-484c-a80e-26c019721c01"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في أساسيات الفيزياء", "First lesson in Second section in Physics Basics", new Guid("410bb0b2-48e0-4c40-a75a-3e027f47a9db") },
                    { new Guid("77c35f9a-cdf3-47dd-9489-5ba0ac5e0129"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في مبادئ الأمن السيبراني", "First lesson in First section in Cyber Security Fundamentals", new Guid("cbbb90ab-d91d-4dc7-b82d-a6fcc246c10d") },
                    { new Guid("78722f3a-7621-41a4-ad7c-9a4179320fdf"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في مقدمة في الذكاء الاصطناعي", "First lesson in Second section in Intro to Artificial Intelligence", new Guid("dddb525b-5ff4-4eb4-ba63-14fbe40d1410") },
                    { new Guid("7d9b9bba-3c44-4194-8edf-44538a37831c"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في مبادئ الأمن السيبراني", "Second lesson in First section in Cyber Security Fundamentals", new Guid("cbbb90ab-d91d-4dc7-b82d-a6fcc246c10d") },
                    { new Guid("81cba95d-6cec-41db-8ab1-743dafbd229a"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في مقدمة في التعليم الإلكتروني", "Second lesson in First section in Intro to E-Learning", new Guid("c6890e07-1117-47c4-8c00-3666c0c53b07") },
                    { new Guid("8618e24e-42ea-4ff0-8d2a-e1efa677deeb"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في مقدمة في الذكاء الاصطناعي", "First lesson in First section in Intro to Artificial Intelligence", new Guid("2164036e-79b6-4bea-93c4-2c69aabc8be3") },
                    { new Guid("8828caa7-5572-4aac-b118-441dee985c51"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في مبادئ الهندسة الميكانيكية", "Second lesson in Second section in Mechanical Engineering Principles", new Guid("aca40286-8d9a-4a35-a669-d9f5001096eb") },
                    { new Guid("952ab269-a144-4d3c-873f-b3d8af74361d"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في أساسيات البرمجة", "First lesson in First section in Programming Basics", new Guid("ebf43faf-7b3a-4f96-bf9d-0538d1a7b5fa") },
                    { new Guid("a38fe5fb-fb33-46a4-a300-7ba6baba3991"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في أساسيات الهندسة الكهربائية", "Second lesson in Second section in Electrical Engineering Basics", new Guid("727d1bb5-d343-49e5-8e09-677ec42fac13") },
                    { new Guid("aa2abfab-53c5-4bcc-a97e-ce8606071e5b"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في مقدمة في الذكاء الاصطناعي", "Second lesson in First section in Intro to Artificial Intelligence", new Guid("2164036e-79b6-4bea-93c4-2c69aabc8be3") },
                    { new Guid("af1f9860-3c80-4cd2-bced-24576229b4a1"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في مبادئ الهندسة الميكانيكية", "Second lesson in First section in Mechanical Engineering Principles", new Guid("c13a86a4-2e5e-492f-9856-9df3fa2cb81a") },
                    { new Guid("b575ba0f-12a9-4c4b-84bd-3d8538f45b51"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في أساسيات الهندسة الكهربائية", "First lesson in First section in Electrical Engineering Basics", new Guid("3651861d-e1a5-4f7b-b659-67f90dfc4ea9") },
                    { new Guid("bd5d17eb-484d-4208-bd35-fefac4159ae2"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في أساسيات الفيزياء", "Second lesson in First section in Physics Basics", new Guid("69a10083-c6f5-4152-9a5d-56d0f3a69fc6") },
                    { new Guid("c48b33f7-b7d0-464b-a044-169eb59b7f10"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في الهندسة المدنية المتقدمة", "Second lesson in Second section in Advanced Civil Engineering", new Guid("86cfdab6-4386-4dce-a410-f452041a92c5") },
                    { new Guid("cad9d6bf-ddd5-48ba-9225-26f47eb0e740"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في أساسيات الفيزياء", "Second lesson in Second section in Physics Basics", new Guid("410bb0b2-48e0-4c40-a75a-3e027f47a9db") },
                    { new Guid("d2280b43-9546-45f4-b607-52cefa775e76"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في مبادئ الأمن السيبراني", "First lesson in Second section in Cyber Security Fundamentals", new Guid("5b76fbfb-56a0-4df2-8f7b-01d484b536e4") },
                    { new Guid("d4c1c7b6-ef3c-4282-8b5a-b9be255a1106"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في أساسيات الفيزياء", "First lesson in First section in Physics Basics", new Guid("69a10083-c6f5-4152-9a5d-56d0f3a69fc6") },
                    { new Guid("d57b8d88-531b-43d0-9d38-95d2e5a9c106"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في أساسيات التسويق الرقمي", "Second lesson in First section in Digital Marketing Basics", new Guid("1ea43531-f953-45e8-8f54-b82e65a4bf6e") },
                    { new Guid("e4e0cf6d-dab4-4ebb-8a3c-d49dc52635c3"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في أساسيات البرمجة", "Second lesson in Second section in Programming Basics", new Guid("d9257731-5392-445c-be5a-dcee51240f05") },
                    { new Guid("e54a0656-21df-4a69-911a-4b812e8e7c80"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في مبادئ الأمن السيبراني", "Second lesson in Second section in Cyber Security Fundamentals", new Guid("5b76fbfb-56a0-4df2-8f7b-01d484b536e4") },
                    { new Guid("ebbe6cb4-4cdb-4433-96b2-58380e1dd217"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في أساسيات التسويق الرقمي", "First lesson in First section in Digital Marketing Basics", new Guid("1ea43531-f953-45e8-8f54-b82e65a4bf6e") },
                    { new Guid("f45ac236-4fdc-4844-a7b1-559582125598"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في الهندسة المدنية المتقدمة", "First lesson in Second section in Advanced Civil Engineering", new Guid("86cfdab6-4386-4dce-a410-f452041a92c5") },
                    { new Guid("f52b4b02-09ba-4745-be41-088e312f824d"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في مقدمة في التعليم الإلكتروني", "First lesson in Second section in Intro to E-Learning", new Guid("7191e2eb-7697-4e59-b644-0b554f312e97") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("0a291d4c-396c-4fa1-87f0-52dd1a34846b"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("17973669-f435-44ec-bf78-6ea35a6808c0"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("2a9534e6-ff65-429f-bea4-ce8a4e82dd08"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("3033d647-ef48-4659-9f44-72cb78c16619"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("31193a54-e372-4057-b3c5-24791ee2ee53"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("3147b17d-6c8d-4574-a168-16031779a714"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("33ca39e0-f8c7-4041-83ae-e12aec9143d8"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("38b6160b-7a49-4b93-89cf-fe85a3627a04"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("47958b8e-19bc-48b1-883a-c1118ea9b1ba"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("4e9ccb74-c4ec-4144-8344-e243f8df8e2a"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("54939d4c-ef6d-4ca5-b74f-6c05f5941b0a"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("5ba67242-68ca-484f-9d39-e9f40816c3b8"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("5bdb0d03-d944-4cbd-99d4-75651ca5f8e5"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("6edf384f-267e-464e-b93c-56d36b73e2f0"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("6f587703-4146-44c9-8cd6-94c4ce49b445"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("7008ce4e-45f6-4d8c-9e46-4174c40a406a"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("73fa375f-21fc-4e35-90dc-5b17f78f0bbb"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("7adde1f4-966e-44ea-aff9-aaccfa779524"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("80580be3-5a6e-4622-8d09-7ecebbac7654"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("81015447-d5c5-44c8-afa1-328221c7e16b"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("85f71c3a-885c-4155-ab87-777e52741295"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("89d426aa-5d1b-4f37-98d6-62270e7b6777"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("8cdf5524-6c92-4a5b-a866-86ea7a007a1c"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("90f9aca4-3544-4021-8a5a-24a8b8071c8c"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("92733b67-ed72-46c7-b9c2-abf5430d0839"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("9d1586ce-3902-4b7a-884f-0c2d029ad0f9"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("a098aa09-9d51-4c9d-94e8-ee15dd3e5e29"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("a47ea557-9bf1-4034-9eaf-916038451ee2"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ad29f6af-1b2b-4a89-9622-3b3244833208"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("c593e849-e78a-44bc-9ac4-84e6dd7bea4d"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("c74e902e-664b-448b-b85a-99f24c60e64e"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("c82b40b3-6483-4955-879f-20e08ef69a35"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("d324cd03-2b03-471c-bbc8-a54909384001"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("d3f7e6b5-d402-43bb-a1f3-d05e811a9673"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("d6c4c48a-8b46-4983-ac61-c69a181cd2eb"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("f325d231-1877-434f-8228-659b033be139"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("f3798180-edf2-4d1b-add3-743ab6d82f32"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("f59b6035-ab82-4f83-bb79-0f16663e3441"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("fd0dacab-2e28-4e6c-9108-85a89b145aef"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ff3fef0b-2242-4469-aa61-c08dd474dbf3"));

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InterestsList",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("03dd8e2a-99cd-4e49-8c0b-9fb791a64fa9"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("08bfee98-434a-452e-a5d3-8fe3570c840c"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0e5065e6-f200-44f1-a0f7-2f48cd1f8952"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("17a24d79-391e-4723-a1ad-337b9facdb30"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("191ab0ca-5400-44b6-90f3-8a6492da96f7"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2096eff2-9b4b-4462-ab4c-1f5af86d60ad"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2c51371a-8124-4a99-9e2c-75524e2ae11c"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("34d847d4-23ba-4329-b79a-b96fc119b745"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("456e5fcc-4dbe-47e1-b69d-a54dc382375a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("48093142-1378-4018-8ffd-fd5890d29cc1"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("4fff1b13-de22-4e3e-963a-eb279d8f4215"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("5b8a656c-9f60-4c4e-8457-93c826a31a4c"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("5c33f7f9-9f06-4003-9c5f-21f44fd70a79"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("5dd4f634-1a7b-4847-acfe-aed5c95b8f2a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("61505696-df1d-4ac0-b39d-639138d8fca9"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("63b7d59e-c194-4bea-951c-945c52bf63e7"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("6aa2ee33-133b-46fc-b492-29ef07f9affd"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("7088e7f9-2922-484c-a80e-26c019721c01"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("77c35f9a-cdf3-47dd-9489-5ba0ac5e0129"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("78722f3a-7621-41a4-ad7c-9a4179320fdf"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("7d9b9bba-3c44-4194-8edf-44538a37831c"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("81cba95d-6cec-41db-8ab1-743dafbd229a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("8618e24e-42ea-4ff0-8d2a-e1efa677deeb"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("8828caa7-5572-4aac-b118-441dee985c51"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("952ab269-a144-4d3c-873f-b3d8af74361d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("a38fe5fb-fb33-46a4-a300-7ba6baba3991"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("aa2abfab-53c5-4bcc-a97e-ce8606071e5b"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("af1f9860-3c80-4cd2-bced-24576229b4a1"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("b575ba0f-12a9-4c4b-84bd-3d8538f45b51"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("bd5d17eb-484d-4208-bd35-fefac4159ae2"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c48b33f7-b7d0-464b-a044-169eb59b7f10"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("cad9d6bf-ddd5-48ba-9225-26f47eb0e740"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d2280b43-9546-45f4-b607-52cefa775e76"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d4c1c7b6-ef3c-4282-8b5a-b9be255a1106"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d57b8d88-531b-43d0-9d38-95d2e5a9c106"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e4e0cf6d-dab4-4ebb-8a3c-d49dc52635c3"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e54a0656-21df-4a69-911a-4b812e8e7c80"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ebbe6cb4-4cdb-4433-96b2-58380e1dd217"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f45ac236-4fdc-4844-a7b1-559582125598"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f52b4b02-09ba-4745-be41-088e312f824d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("263dd1e4-a4ed-49c6-bc44-70756c3bf72e"), new Guid("472f5d43-3fa0-4520-b9ec-bb1f71057159") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("778ca486-55a7-4318-aed3-4212b04f9864"), new Guid("472f5d43-3fa0-4520-b9ec-bb1f71057159") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("149f3f36-e15b-4b6e-b60e-04df4879e86b"), new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("263dd1e4-a4ed-49c6-bc44-70756c3bf72e"), new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("778ca486-55a7-4318-aed3-4212b04f9864"), new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d") });

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserInterstes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("08660b0f-a4db-40e6-9813-be1f31102012"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("0daf3353-5b9e-45c7-bdb1-76f8b2d7de68"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("19e99943-84a7-4f5d-a678-3bf1a39f25cf"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("1ebc4790-2b92-4b1e-986d-789596d251c9"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("479aea90-8844-4610-840c-cec703a0ca02"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("4ad71fb4-6b5f-462a-bd8c-bfef326443ce"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("72ba785f-7bca-4de2-ad88-495bb4582750"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("77cf0ec6-ec28-4b02-b1bd-d0f8dfc7da32"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("88fccafd-d8bc-43f9-a2f6-757004fbd049"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("93fc72ed-065e-4c8e-a333-179e8cf4db84"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("9c1ca49c-91e2-4fa2-be25-3acad4ecba75"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("ac649b42-34ad-4908-aadb-19e80fcd993e"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("b0e542ad-595d-4d76-9da1-208e0e74334a"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("c744cfeb-e39a-49fc-9efb-0a6334832519"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("cab6047f-5dc4-41aa-a566-df3985525f66"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("d3354784-0934-489b-b41c-cb1e0d6cf992"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("e7c2d7e3-e0f9-4f7e-96a9-dc3e34524c9d"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("ed906c6f-fb95-4052-afcc-1fe13aef4abb"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("ee86f84b-6238-4324-8148-2a8870068c5d"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("f295fcd2-5ecc-4e5f-8c99-4f21d1c438aa"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("149f3f36-e15b-4b6e-b60e-04df4879e86b"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("263dd1e4-a4ed-49c6-bc44-70756c3bf72e"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("778ca486-55a7-4318-aed3-4212b04f9864"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("1794a715-51ca-4753-a849-2afec386f464"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("1ea43531-f953-45e8-8f54-b82e65a4bf6e"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("2164036e-79b6-4bea-93c4-2c69aabc8be3"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("3651861d-e1a5-4f7b-b659-67f90dfc4ea9"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("410bb0b2-48e0-4c40-a75a-3e027f47a9db"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("46bc47ec-15cb-4371-9fb3-2ed0dafe4ef6"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("50816fa6-7b7a-4ae7-8168-b3b48f15c8f0"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("5b76fbfb-56a0-4df2-8f7b-01d484b536e4"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("69a10083-c6f5-4152-9a5d-56d0f3a69fc6"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("7191e2eb-7697-4e59-b644-0b554f312e97"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("727d1bb5-d343-49e5-8e09-677ec42fac13"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("86cfdab6-4386-4dce-a410-f452041a92c5"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("aca40286-8d9a-4a35-a669-d9f5001096eb"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("c13a86a4-2e5e-492f-9856-9df3fa2cb81a"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("c6890e07-1117-47c4-8c00-3666c0c53b07"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("cbbb90ab-d91d-4dc7-b82d-a6fcc246c10d"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("d9257731-5392-445c-be5a-dcee51240f05"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("dddb525b-5ff4-4eb4-ba63-14fbe40d1410"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("ebf43faf-7b3a-4f96-bf9d-0538d1a7b5fa"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("ff6dd14d-fa23-4347-b882-85cedf0e4158"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2f8155-a3bd-4de7-94a6-573ff703b82f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3763cc02-ae69-4d91-8f7d-b4396eef6866"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5c475ed1-3980-4323-81c7-055a08de3a18"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("679cb9c1-2f8b-460d-a245-cf65d6048fef"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6861427e-b790-457f-ad6a-8ce1ce21b27e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1ebe749-a80c-475e-a503-c217e77496be"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4b1a857-45ff-4f28-a81b-c5d952a19f1f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d54b92a3-540a-4b6f-8985-12791ee63263"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5ab757d-796b-4de6-ad84-34711bd86c5c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f9b39dda-34a0-4466-96ba-0597cb45d3bf"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("5cc91fe4-bad4-4a14-b6cf-ade12e873e85"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("60b3f428-1327-4fb2-be86-e2092b562d53"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("72686a55-4931-48cf-b9ab-b52d205c8807"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("739dfa86-391e-461f-b2a0-157f2cb911e7"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("91094748-1873-4547-b0eb-f9058858ab35"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("9b057b08-6ea0-4436-9264-4eddd09e42d7"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a1e1e039-1f5d-44a1-9098-52b06744a0cf"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("dde02ce6-99c3-445c-b8ba-e313dbc89efc"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e504354f-16b5-44f5-9a70-9b54b2c53876"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f4e28887-491a-4c29-bcbf-2cfb49b35f12"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("472f5d43-3fa0-4520-b9ec-bb1f71057159"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("654e1ebe-a09e-4ef5-b2bb-c398dba20d4d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d5237557-95cd-48d4-98d7-ba9ea24e20f3"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("0959c1a0-f522-4f71-a2c9-9a7837d661c8"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("20bbdc4e-55ec-45b8-8cb3-e6fd13a1cf93"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("2a13463e-5ebd-4288-9c96-6fd676a79e99"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("3b34131c-7f07-4a81-bea8-b42215bd45c1"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("5a97ef33-c59e-40d5-af0d-14a7c5b4dc5d"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("85350a49-62a3-4409-bc13-89e5a5ff976a"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("b899531d-52ed-4666-9b69-bb71a84bb44e"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("b9c5f8b6-64d4-4f31-a123-6ac65b9b37b4"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("c6cef3a2-a3b6-4847-ac05-20bb94abdbde"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("d4db78a5-e300-42d6-92fd-a3f1470a9cd0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("197ebb1e-56b4-4f07-809c-538da1906582"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2a2f5a02-1d93-445e-8d7f-cd335e21b367"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b4a8ede-f43e-42cb-a620-688154f117b6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3dfec3e8-6266-4c3f-8787-1c0e60cce130"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("46479c8b-3542-4eed-a1f5-1b643d41c48d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("635ec97e-5302-4666-9055-3d975044ad3a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6af6c12a-8daa-4ca1-9f2b-a9dc66b335a4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("875c706b-ba8d-40bb-bac5-c5dfa6558244"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9722e320-a60d-4c9d-9b52-8060d6a95a17"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d0434c1a-7d66-4536-897b-e0e3e47a5829"));

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("22660d27-b55d-494b-9a48-499e9253ece7"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("25815a39-2d62-437f-97df-8e94f0bad870"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3b100d6a-e395-44cc-a1df-05eb30075486"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("409902a4-1543-4075-b409-e4df8987340d"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("5498f95f-2125-40e9-ac3e-4b663ec1f3ad"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("6e97b85d-73ad-46f4-afff-d523507fb41e"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("a1c79a07-d2bd-41e9-a59d-1f36a44d9328"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("ab9a5150-7141-45ca-b46d-20aad6f08f99"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("bb055054-4dce-4a1c-ac58-c8a0fd2b7408"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("f70ff1d6-5feb-44ab-9287-9873b20dcbea"));
        }
    }
}
