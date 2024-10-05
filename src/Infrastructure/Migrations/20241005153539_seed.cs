using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlexBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2d688e72-4d72-4782-a6fc-f8bf5d0a9dbb"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("873d0392-0f27-4a86-bafe-f01937c5a3de"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("fd2885e0-3bb0-4655-8860-955cd05f36c6"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("1f0900ad-6f47-48b4-be40-355952e61f9f"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("9e241f2d-8b33-4368-9c89-fa8c2bb57433"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("89b6a553-47fc-472f-8ba9-8ad1db96de56"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d9c269e4-fcef-4707-8da8-14338c723921"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1e2d8f57-ba8f-41f9-8e34-2f4872460da6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6e659c52-b027-4e77-9b51-d08401674b87"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("0c80243b-c850-49a8-92b5-deb74c3af7e1"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("1a11508a-d9d4-4b2f-a00d-f83cfd7fbd95"));

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
                table: "Topics",
                columns: new[] { "Id", "IsActive", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("0c09e037-1c0e-44f5-847a-9d6843047a47"), false, "التسويق الرقمي", "Digital Marketing" },
                    { new Guid("0d95f453-c111-4b67-b884-322d8e4cb89d"), false, "الهندسة الميكانيكية", "Mechanical Engineering" },
                    { new Guid("3bad6969-0481-4d1e-9d78-ebf8e1d60b3c"), false, "الهندسة الكهربائية", "Electrical Engineering" },
                    { new Guid("777da8e0-8571-446c-9ed1-08d365ed3a93"), false, "التعليم الإلكتروني", "E-Learning" },
                    { new Guid("9c9dec31-2568-45d2-93e2-b0bd997cf157"), false, "تحليل البيانات", "Data Analysis" },
                    { new Guid("a17b04ef-f261-4089-b63b-6d512ff7664f"), false, "الهندسة المدنية", "Civil Engineering" },
                    { new Guid("bba9319e-cfa3-4e49-806c-aec8a108af88"), false, "تطوير البرمجيات", "Software Development" },
                    { new Guid("be2f5b63-7ac1-49d4-ae66-312445025b18"), false, "الأمن السيبراني", "Cyber Security" },
                    { new Guid("d0c66db6-8b86-4dd2-8852-19baee3b7f3c"), false, "الذكاء الاصطناعي", "Artificial Intelligence" },
                    { new Guid("ed20f329-4daf-4cdf-ba3d-9d129345ac24"), false, "العلوم الفيزيائية", "Physical Sciences" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "NameAr", "NameEn", "TopicId" },
                values: new object[,]
                {
                    { new Guid("1210ad0c-0043-47bb-9543-ffe58cd6c3a6"), false, "ذكاء اصطناعي", "Artificial Intelligence", new Guid("d0c66db6-8b86-4dd2-8852-19baee3b7f3c") },
                    { new Guid("4ba2a722-5622-4b9f-a386-8db07c865c2c"), false, "تعليم إلكتروني", "E-Learning", new Guid("777da8e0-8571-446c-9ed1-08d365ed3a93") },
                    { new Guid("591d5b94-cb3d-4c47-8fd7-62dccb6ab239"), false, "هندسة مدنية", "Civil Engineering", new Guid("a17b04ef-f261-4089-b63b-6d512ff7664f") },
                    { new Guid("63464890-61ee-4906-8010-5833ea62bd08"), false, "برمجة", "Programming", new Guid("bba9319e-cfa3-4e49-806c-aec8a108af88") },
                    { new Guid("83f11885-011f-4fb1-90e6-35f1098352c9"), false, "علوم فيزيائية", "Physical Sciences", new Guid("ed20f329-4daf-4cdf-ba3d-9d129345ac24") },
                    { new Guid("aca856cb-bb73-4370-a971-c8fc5103c519"), false, "هندسة ميكانيكية", "Mechanical Engineering", new Guid("0d95f453-c111-4b67-b884-322d8e4cb89d") },
                    { new Guid("b2d96a13-883b-435a-bdb2-562be473371d"), false, "تحليل البيانات", "Data Analysis", new Guid("9c9dec31-2568-45d2-93e2-b0bd997cf157") },
                    { new Guid("f613a892-3833-4ba3-9e80-a4ca965c42d4"), false, "تسويق رقمي", "Digital Marketing", new Guid("0c09e037-1c0e-44f5-847a-9d6843047a47") },
                    { new Guid("f87b222f-c457-47ac-9a71-d1ce6813af62"), false, "أمن سيبراني", "Cyber Security", new Guid("be2f5b63-7ac1-49d4-ae66-312445025b18") },
                    { new Guid("fb4ca459-47f5-4619-a6e7-45d17c9bb3f0"), false, "هندسة كهربائية", "Electrical Engineering", new Guid("3bad6969-0481-4d1e-9d78-ebf8e1d60b3c") }
                });

            migrationBuilder.InsertData(
                table: "University",
                columns: new[] { "Id", "CountryId", "IsActive", "LookUpStatus", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("0031e422-a013-41c6-ba5f-14bac83b55af"), 7, false, 2, "جامعة البرازيل", "University of Brazil" },
                    { new Guid("09463ad4-d48a-424e-8e1d-66fd11d069a8"), 2, false, 2, "جامعة المملكة المتحدة", "University of United Kingdom" },
                    { new Guid("298d44bf-6d3c-4095-aff3-c1fd86d7bad0"), 5, false, 2, "جامعة الهند", "University of India" },
                    { new Guid("486ec9eb-3a2d-4b29-b4dd-892accb188ec"), 1, false, 2, "جامعة الولايات المتحدة", "University of United States" },
                    { new Guid("aaf6723f-4dc3-4971-a7fa-e5b597580d69"), 3, false, 2, "جامعة كندا", "University of Canada" },
                    { new Guid("bd47ddec-9d65-4331-a8fc-e8490d3a9042"), 8, false, 2, "جامعة اليابان", "University of Japan" },
                    { new Guid("d4648f3d-0413-4e93-8145-ba686c630b3e"), 10, false, 2, "جامعة الإمارات العربية المتحدة", "University of United Arab Emirates" },
                    { new Guid("d7bb4edf-86e1-408d-936d-4398f6ae1abe"), 6, false, 2, "جامعة ألمانيا", "University of Germany" },
                    { new Guid("e8df9a64-3e8e-48b2-9cff-166a92fa409e"), 4, false, 2, "جامعة أستراليا", "University of Australia" },
                    { new Guid("ed347594-f1d0-4228-b293-d96cf7a447c1"), 9, false, 2, "جامعة فرنسا", "University of France" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CountryId", "Created", "CreatedBy", "DepartmentId", "Email", "FacultyId", "FirstName", "LastModified", "LastModifiedBy", "LastModifiedStatus", "LastName", "MobileNumber", "Password", "RegisterAt", "Status", "UniversityId", "UserType" },
                values: new object[,]
                {
                    { new Guid("08cf98b1-41ed-4a48-affc-5f280b632070"), 2, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(8965), null, null, "user1@example.com", null, "User1", null, null, null, "LastName1", "1234567891", "password1", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(8892), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 },
                    { new Guid("0b7a7461-287a-4f8a-8668-92c8906c07ed"), 6, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(9043), null, null, "user5@example.com", null, "User5", null, null, null, "LastName5", "1234567895", "password5", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(9007), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 },
                    { new Guid("14e78d9c-38d8-41a5-ad6d-771f27737d29"), 10, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(9078), null, null, "user9@example.com", null, "User9", null, null, null, "LastName9", "1234567899", "password9", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(9074), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 },
                    { new Guid("3f9ea1d3-54b2-46c8-b26b-188c2703828e"), 4, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(8991), null, null, "user3@example.com", null, "User3", null, null, null, "LastName3", "1234567893", "password3", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(8988), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 },
                    { new Guid("5530ac02-7f1a-49a2-90fb-742bb873aa7d"), 5, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(9002), null, null, "user4@example.com", null, "User4", null, null, null, "LastName4", "1234567894", "password4", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(8999), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 },
                    { new Guid("5fd02879-31ea-487a-b68b-1700b3d27798"), 7, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(9053), null, null, "user6@example.com", null, "User6", null, null, null, "LastName6", "1234567896", "password6", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 },
                    { new Guid("94aa3d9b-c547-4ff9-8c10-c6de8a01b1a9"), 9, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(9070), null, null, "user8@example.com", null, "User8", null, null, null, "LastName8", "1234567898", "password8", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(9066), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 },
                    { new Guid("aac40201-6f3f-4b45-881d-e734d742504e"), 3, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(8983), null, null, "user2@example.com", null, "User2", null, null, null, "LastName2", "1234567892", "password2", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(8979), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 },
                    { new Guid("cf400225-260c-4e01-8f29-382f2b0cbfce"), 8, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(9062), null, null, "user7@example.com", null, "User7", null, null, null, "LastName7", "1234567897", "password7", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(9058), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 },
                    { new Guid("ef58cc66-522e-4f4a-83d2-de3778bc890f"), 1, new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Local).AddTicks(9087), null, null, "user10@example.com", null, "User10", null, null, null, "LastName10", "12345678910", "password10", new DateTimeOffset(new DateTime(2024, 10, 5, 18, 35, 38, 925, DateTimeKind.Unspecified).AddTicks(9084), new TimeSpan(0, 3, 0, 0, 0)), 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CoverPhoto", "DiscriptionAr", "DiscriptionEn", "IsActive", "NameAr", "NameEn", "TopicId" },
                values: new object[,]
                {
                    { new Guid("0bbc5774-c938-4b62-982e-f770be1c3882"), new Guid("b2d96a13-883b-435a-bdb2-562be473371d"), "data_analysis.jpg", "دورة تعلم تحليل البيانات المتقدم", "Learn advanced data analysis", false, "تحليل البيانات المتقدم", "Advanced Data Analysis", new Guid("9c9dec31-2568-45d2-93e2-b0bd997cf157") },
                    { new Guid("49abba9b-2835-404d-afc6-8e0aba80be77"), new Guid("fb4ca459-47f5-4619-a6e7-45d17c9bb3f0"), "electrical_engineering.jpg", "دورة تعلم أساسيات الهندسة الكهربائية", "Learn the basics of electrical engineering", false, "أساسيات الهندسة الكهربائية", "Electrical Engineering Basics", new Guid("3bad6969-0481-4d1e-9d78-ebf8e1d60b3c") },
                    { new Guid("56e357a1-bda0-412a-ad68-6ab234fe1502"), new Guid("aca856cb-bb73-4370-a971-c8fc5103c519"), "mechanical_engineering.jpg", "دورة تعلم مبادئ الهندسة الميكانيكية", "Learn the principles of mechanical engineering", false, "مبادئ الهندسة الميكانيكية", "Mechanical Engineering Principles", new Guid("0d95f453-c111-4b67-b884-322d8e4cb89d") },
                    { new Guid("72dbc6b0-2f7e-4784-95e6-a276df58839f"), new Guid("4ba2a722-5622-4b9f-a386-8db07c865c2c"), "e_learning.jpg", "دورة تعلم مبادئ التعليم الإلكتروني", "Introduction to e-learning", false, "مقدمة في التعليم الإلكتروني", "Intro to E-Learning", new Guid("777da8e0-8571-446c-9ed1-08d365ed3a93") },
                    { new Guid("832cee7c-99e5-42ee-af2b-51aa1d3177d9"), new Guid("f613a892-3833-4ba3-9e80-a4ca965c42d4"), "digital_marketing.jpg", "دورة تعلم أساسيات التسويق الرقمي", "Learn the basics of digital marketing", false, "أساسيات التسويق الرقمي", "Digital Marketing Basics", new Guid("0c09e037-1c0e-44f5-847a-9d6843047a47") },
                    { new Guid("9d6d03c0-2bcb-47b4-ad8e-0fcfc3c3c04b"), new Guid("591d5b94-cb3d-4c47-8fd7-62dccb6ab239"), "civil_engineering.jpg", "دورة تعلم الهندسة المدنية المتقدمة", "Learn advanced civil engineering", false, "الهندسة المدنية المتقدمة", "Advanced Civil Engineering", new Guid("a17b04ef-f261-4089-b63b-6d512ff7664f") },
                    { new Guid("a3a9662f-4a77-406c-8171-2fcbb9bdd401"), new Guid("1210ad0c-0043-47bb-9543-ffe58cd6c3a6"), "ai_intro.jpg", "دورة مقدمة في الذكاء الاصطناعي", "Introduction to Artificial Intelligence", false, "مقدمة في الذكاء الاصطناعي", "Intro to Artificial Intelligence", new Guid("d0c66db6-8b86-4dd2-8852-19baee3b7f3c") },
                    { new Guid("c5be303b-fc25-445d-a9bc-0c9351258ca8"), new Guid("63464890-61ee-4906-8010-5833ea62bd08"), "programming_basics.jpg", "دورة تعلم أساسيات البرمجة", "Learn the basics of programming", false, "أساسيات البرمجة", "Programming Basics", new Guid("bba9319e-cfa3-4e49-806c-aec8a108af88") },
                    { new Guid("ca2f8ee4-68ea-4228-9f72-6179afef271c"), new Guid("83f11885-011f-4fb1-90e6-35f1098352c9"), "physics_basics.jpg", "دورة تعلم أساسيات الفيزياء", "Learn the basics of physics", false, "أساسيات الفيزياء", "Physics Basics", new Guid("ed20f329-4daf-4cdf-ba3d-9d129345ac24") },
                    { new Guid("df8699b0-8b9a-4be5-9639-20e2d9e48d33"), new Guid("f87b222f-c457-47ac-9a71-d1ce6813af62"), "cyber_security.jpg", "دورة تعلم مبادئ الأمن السيبراني", "Learn the fundamentals of cyber security", false, "مبادئ الأمن السيبراني", "Cyber Security Fundamentals", new Guid("be2f5b63-7ac1-49d4-ae66-312445025b18") }
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "IsActive", "LookUpStatus", "NameAr", "NameEn", "UniversityId" },
                values: new object[,]
                {
                    { new Guid("0706a5b2-01e9-4bec-8c42-68dd382adb00"), false, 2, "كلية الهندسة في جامعة الهند", "Faculty of Engineering in University of India", new Guid("298d44bf-6d3c-4095-aff3-c1fd86d7bad0") },
                    { new Guid("0905d706-2d5f-46cc-98e1-b8199ea4ed1f"), false, 2, "كلية العلوم في جامعة فرنسا", "Faculty of Science in University of France", new Guid("ed347594-f1d0-4228-b293-d96cf7a447c1") },
                    { new Guid("0da48415-7c80-403b-ae00-e6167c7abfc6"), false, 2, "كلية الهندسة في جامعة الولايات المتحدة", "Faculty of Engineering in University of United States", new Guid("486ec9eb-3a2d-4b29-b4dd-892accb188ec") },
                    { new Guid("185df395-22cb-4ef7-90ca-1ae526a07656"), false, 2, "كلية الهندسة في جامعة ألمانيا", "Faculty of Engineering in University of Germany", new Guid("d7bb4edf-86e1-408d-936d-4398f6ae1abe") },
                    { new Guid("293a93de-1b39-4ab1-a497-3e1871593bb2"), false, 2, "كلية العلوم في جامعة المملكة المتحدة", "Faculty of Science in University of United Kingdom", new Guid("09463ad4-d48a-424e-8e1d-66fd11d069a8") },
                    { new Guid("32aef844-1b6e-4521-a775-06433ce50133"), false, 2, "كلية الهندسة في جامعة كندا", "Faculty of Engineering in University of Canada", new Guid("aaf6723f-4dc3-4971-a7fa-e5b597580d69") },
                    { new Guid("4f448d6d-7eec-42d2-b44f-95fae2256011"), false, 2, "كلية الهندسة في جامعة الإمارات العربية المتحدة", "Faculty of Engineering in University of United Arab Emirates", new Guid("d4648f3d-0413-4e93-8145-ba686c630b3e") },
                    { new Guid("5704d6d5-913d-4d69-aa5c-ac0f0dd9c8db"), false, 2, "كلية العلوم في جامعة الولايات المتحدة", "Faculty of Science in University of United States", new Guid("486ec9eb-3a2d-4b29-b4dd-892accb188ec") },
                    { new Guid("5f543fef-fbd9-44fc-82fe-cb46b7234a54"), false, 2, "كلية العلوم في جامعة الهند", "Faculty of Science in University of India", new Guid("298d44bf-6d3c-4095-aff3-c1fd86d7bad0") },
                    { new Guid("821bd343-34cb-46c3-9a23-c1368ed30032"), false, 2, "كلية الهندسة في جامعة المملكة المتحدة", "Faculty of Engineering in University of United Kingdom", new Guid("09463ad4-d48a-424e-8e1d-66fd11d069a8") },
                    { new Guid("83739f63-4b59-42ea-9f0e-f05742d8e965"), false, 2, "كلية الهندسة في جامعة أستراليا", "Faculty of Engineering in University of Australia", new Guid("e8df9a64-3e8e-48b2-9cff-166a92fa409e") },
                    { new Guid("83e2d83b-ff9a-4931-bcc8-010e1951aae9"), false, 2, "كلية العلوم في جامعة اليابان", "Faculty of Science in University of Japan", new Guid("bd47ddec-9d65-4331-a8fc-e8490d3a9042") },
                    { new Guid("8bf93b3a-5521-4bba-9d07-cbc4d7747b71"), false, 2, "كلية العلوم في جامعة الإمارات العربية المتحدة", "Faculty of Science in University of United Arab Emirates", new Guid("d4648f3d-0413-4e93-8145-ba686c630b3e") },
                    { new Guid("a5f1fd3f-cb3b-44b2-8d8c-e03ad693720f"), false, 2, "كلية العلوم في جامعة أستراليا", "Faculty of Science in University of Australia", new Guid("e8df9a64-3e8e-48b2-9cff-166a92fa409e") },
                    { new Guid("c46a057a-3e34-4eee-906e-c53fe957d808"), false, 2, "كلية الهندسة في جامعة البرازيل", "Faculty of Engineering in University of Brazil", new Guid("0031e422-a013-41c6-ba5f-14bac83b55af") },
                    { new Guid("d03eb6af-a058-42be-80e8-f33414004104"), false, 2, "كلية العلوم في جامعة البرازيل", "Faculty of Science in University of Brazil", new Guid("0031e422-a013-41c6-ba5f-14bac83b55af") },
                    { new Guid("d1d58918-7cec-4f60-9d8e-9bd8e316dc49"), false, 2, "كلية الهندسة في جامعة اليابان", "Faculty of Engineering in University of Japan", new Guid("bd47ddec-9d65-4331-a8fc-e8490d3a9042") },
                    { new Guid("d37420c4-c5d8-4bf4-a0d4-e5c2089869b0"), false, 2, "كلية الهندسة في جامعة فرنسا", "Faculty of Engineering in University of France", new Guid("ed347594-f1d0-4228-b293-d96cf7a447c1") },
                    { new Guid("efe30e31-9ba3-4ea8-b7f1-a246c9ced7f7"), false, 2, "كلية العلوم في جامعة كندا", "Faculty of Science in University of Canada", new Guid("aaf6723f-4dc3-4971-a7fa-e5b597580d69") },
                    { new Guid("f27a1b67-1262-4aad-bb5d-0f3449b4439f"), false, 2, "كلية العلوم في جامعة ألمانيا", "Faculty of Science in University of Germany", new Guid("d7bb4edf-86e1-408d-936d-4398f6ae1abe") }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "FacultyId", "IsActive", "LookUpStatus", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("020884ae-3139-4929-b1f4-0acba046f88a"), new Guid("8bf93b3a-5521-4bba-9d07-cbc4d7747b71"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة الإمارات العربية المتحدة", "Department of Physics in Faculty of Science in University of United Arab Emirates" },
                    { new Guid("03949101-1d7b-49cf-a575-364ad51707a8"), new Guid("4f448d6d-7eec-42d2-b44f-95fae2256011"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة الإمارات العربية المتحدة", "Department of Computer Science in Faculty of Engineering in University of United Arab Emirates" },
                    { new Guid("08854305-81ca-41fb-a060-b063a2b5b2c1"), new Guid("a5f1fd3f-cb3b-44b2-8d8c-e03ad693720f"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة أستراليا", "Department of Computer Science in Faculty of Science in University of Australia" },
                    { new Guid("0e1c832e-255d-47b1-9dc6-e03c23da1c45"), new Guid("293a93de-1b39-4ab1-a497-3e1871593bb2"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة المملكة المتحدة", "Department of Physics in Faculty of Science in University of United Kingdom" },
                    { new Guid("11d6a90b-5e2b-4605-be20-108393cc476a"), new Guid("185df395-22cb-4ef7-90ca-1ae526a07656"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة ألمانيا", "Department of Physics in Faculty of Engineering in University of Germany" },
                    { new Guid("1c11ef7b-ebc3-4de2-9878-007744b0d50a"), new Guid("5f543fef-fbd9-44fc-82fe-cb46b7234a54"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة الهند", "Department of Physics in Faculty of Science in University of India" },
                    { new Guid("1e75961d-4321-4221-b064-d0363b619913"), new Guid("83e2d83b-ff9a-4931-bcc8-010e1951aae9"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة اليابان", "Department of Computer Science in Faculty of Science in University of Japan" },
                    { new Guid("1f090b3e-1474-49bb-bcdd-6a1114dc26d0"), new Guid("efe30e31-9ba3-4ea8-b7f1-a246c9ced7f7"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة كندا", "Department of Physics in Faculty of Science in University of Canada" },
                    { new Guid("29e5fba1-014b-4df1-9dfe-a22603130d91"), new Guid("5704d6d5-913d-4d69-aa5c-ac0f0dd9c8db"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة الولايات المتحدة", "Department of Computer Science in Faculty of Science in University of United States" },
                    { new Guid("3a01dd98-f0a4-49f2-9e2a-0f3c4971e78c"), new Guid("0da48415-7c80-403b-ae00-e6167c7abfc6"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة الولايات المتحدة", "Department of Physics in Faculty of Engineering in University of United States" },
                    { new Guid("3dd73a64-6f78-4e7c-88b4-ca4d1e8a7886"), new Guid("0da48415-7c80-403b-ae00-e6167c7abfc6"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة الولايات المتحدة", "Department of Computer Science in Faculty of Engineering in University of United States" },
                    { new Guid("49e04076-ea1d-4bd7-bf44-f449d2ee024d"), new Guid("32aef844-1b6e-4521-a775-06433ce50133"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة كندا", "Department of Computer Science in Faculty of Engineering in University of Canada" },
                    { new Guid("548bb328-7d86-4072-bba5-0d6cb65cf8f8"), new Guid("d1d58918-7cec-4f60-9d8e-9bd8e316dc49"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة اليابان", "Department of Computer Science in Faculty of Engineering in University of Japan" },
                    { new Guid("5509de13-be01-41c5-a8d9-149f8d4ec49b"), new Guid("83739f63-4b59-42ea-9f0e-f05742d8e965"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة أستراليا", "Department of Physics in Faculty of Engineering in University of Australia" },
                    { new Guid("552fd439-53aa-4a9f-aeb4-695d59279a37"), new Guid("f27a1b67-1262-4aad-bb5d-0f3449b4439f"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة ألمانيا", "Department of Physics in Faculty of Science in University of Germany" },
                    { new Guid("5966ba6c-96c8-4f24-a5a2-8c7a4d44717b"), new Guid("d1d58918-7cec-4f60-9d8e-9bd8e316dc49"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة اليابان", "Department of Physics in Faculty of Engineering in University of Japan" },
                    { new Guid("65896beb-b573-46dd-ac65-6fe48eb792e9"), new Guid("d37420c4-c5d8-4bf4-a0d4-e5c2089869b0"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة فرنسا", "Department of Computer Science in Faculty of Engineering in University of France" },
                    { new Guid("68bfffed-7357-4631-ade0-344bb5d3d18e"), new Guid("d37420c4-c5d8-4bf4-a0d4-e5c2089869b0"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة فرنسا", "Department of Physics in Faculty of Engineering in University of France" },
                    { new Guid("7a98e3b9-6b45-4a32-ac64-ff09deea02a2"), new Guid("185df395-22cb-4ef7-90ca-1ae526a07656"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة ألمانيا", "Department of Computer Science in Faculty of Engineering in University of Germany" },
                    { new Guid("8121fa6e-296e-49aa-970f-936b8db17860"), new Guid("83e2d83b-ff9a-4931-bcc8-010e1951aae9"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة اليابان", "Department of Physics in Faculty of Science in University of Japan" },
                    { new Guid("88309015-d779-4a64-acc2-4cfa53f1a460"), new Guid("0706a5b2-01e9-4bec-8c42-68dd382adb00"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة الهند", "Department of Computer Science in Faculty of Engineering in University of India" },
                    { new Guid("91ad6eb1-1ab4-48d1-985d-d368c590d228"), new Guid("0706a5b2-01e9-4bec-8c42-68dd382adb00"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة الهند", "Department of Physics in Faculty of Engineering in University of India" },
                    { new Guid("9cf66ed9-5361-4e35-b961-736c0c04f46e"), new Guid("0905d706-2d5f-46cc-98e1-b8199ea4ed1f"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة فرنسا", "Department of Computer Science in Faculty of Science in University of France" },
                    { new Guid("9e5dd471-6f05-434f-9175-77490920ed8f"), new Guid("efe30e31-9ba3-4ea8-b7f1-a246c9ced7f7"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة كندا", "Department of Computer Science in Faculty of Science in University of Canada" },
                    { new Guid("9fccf490-85fe-4b0e-8594-8a8013b7d57c"), new Guid("293a93de-1b39-4ab1-a497-3e1871593bb2"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة المملكة المتحدة", "Department of Computer Science in Faculty of Science in University of United Kingdom" },
                    { new Guid("a5694454-7fbc-4c34-9c97-aa6e33def9e8"), new Guid("8bf93b3a-5521-4bba-9d07-cbc4d7747b71"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة الإمارات العربية المتحدة", "Department of Computer Science in Faculty of Science in University of United Arab Emirates" },
                    { new Guid("a8b12a29-b077-46d7-91f9-ce36587dcfeb"), new Guid("d03eb6af-a058-42be-80e8-f33414004104"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة البرازيل", "Department of Physics in Faculty of Science in University of Brazil" },
                    { new Guid("a90ba18f-880d-4393-b5be-ee4a39791054"), new Guid("c46a057a-3e34-4eee-906e-c53fe957d808"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة البرازيل", "Department of Physics in Faculty of Engineering in University of Brazil" },
                    { new Guid("b0748877-7c7d-43a9-be0e-247a05b020dc"), new Guid("f27a1b67-1262-4aad-bb5d-0f3449b4439f"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة ألمانيا", "Department of Computer Science in Faculty of Science in University of Germany" },
                    { new Guid("c00ddbf8-656c-4b07-a093-4400be39b2ee"), new Guid("c46a057a-3e34-4eee-906e-c53fe957d808"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة البرازيل", "Department of Computer Science in Faculty of Engineering in University of Brazil" },
                    { new Guid("c07c5a85-633f-4b0a-9aa4-7a4cb12846ee"), new Guid("0905d706-2d5f-46cc-98e1-b8199ea4ed1f"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة فرنسا", "Department of Physics in Faculty of Science in University of France" },
                    { new Guid("c0b14ffe-7a00-4ef2-b21b-bb325936b578"), new Guid("5704d6d5-913d-4d69-aa5c-ac0f0dd9c8db"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة الولايات المتحدة", "Department of Physics in Faculty of Science in University of United States" },
                    { new Guid("cc35130e-c5d5-4a61-aaee-7b52b59350a0"), new Guid("821bd343-34cb-46c3-9a23-c1368ed30032"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة المملكة المتحدة", "Department of Physics in Faculty of Engineering in University of United Kingdom" },
                    { new Guid("ce67fa4c-286f-4758-9de4-c336458b70b7"), new Guid("a5f1fd3f-cb3b-44b2-8d8c-e03ad693720f"), false, 2, "قسم الفيزياء في كلية العلوم في جامعة أستراليا", "Department of Physics in Faculty of Science in University of Australia" },
                    { new Guid("d0a1d44f-04cb-4305-9922-2110d7672517"), new Guid("4f448d6d-7eec-42d2-b44f-95fae2256011"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة الإمارات العربية المتحدة", "Department of Physics in Faculty of Engineering in University of United Arab Emirates" },
                    { new Guid("d7273913-8f10-4dc9-9c25-50087c30ae17"), new Guid("5f543fef-fbd9-44fc-82fe-cb46b7234a54"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة الهند", "Department of Computer Science in Faculty of Science in University of India" },
                    { new Guid("e50a382e-8960-4fb0-b10f-a0a83ef9541a"), new Guid("821bd343-34cb-46c3-9a23-c1368ed30032"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة المملكة المتحدة", "Department of Computer Science in Faculty of Engineering in University of United Kingdom" },
                    { new Guid("e79dfd14-7c85-414b-b19e-23aac7a0f209"), new Guid("83739f63-4b59-42ea-9f0e-f05742d8e965"), false, 2, "قسم علوم الحاسوب في كلية الهندسة في جامعة أستراليا", "Department of Computer Science in Faculty of Engineering in University of Australia" },
                    { new Guid("f4ef9b95-62cf-4eff-b987-e05310c06997"), new Guid("d03eb6af-a058-42be-80e8-f33414004104"), false, 2, "قسم علوم الحاسوب في كلية العلوم في جامعة البرازيل", "Department of Computer Science in Faculty of Science in University of Brazil" },
                    { new Guid("fbe57a7f-902c-49d2-bb1f-fca792914c22"), new Guid("32aef844-1b6e-4521-a775-06433ce50133"), false, 2, "قسم الفيزياء في كلية الهندسة في جامعة كندا", "Department of Physics in Faculty of Engineering in University of Canada" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "IsActive", "TitleAr", "TitleEn" },
                values: new object[,]
                {
                    { new Guid("065a51f3-a037-4210-907b-4aeb89d268c7"), new Guid("72dbc6b0-2f7e-4784-95e6-a276df58839f"), false, "القسم الثاني في مقدمة في التعليم الإلكتروني", "Second section in Intro to E-Learning" },
                    { new Guid("09a0bb15-5df4-442b-83cf-65686a778168"), new Guid("0bbc5774-c938-4b62-982e-f770be1c3882"), false, "القسم الأول في تحليل البيانات المتقدم", "First section in Advanced Data Analysis" },
                    { new Guid("1380a77d-2531-4935-b1a7-01e44f9a355f"), new Guid("a3a9662f-4a77-406c-8171-2fcbb9bdd401"), false, "القسم الأول في مقدمة في الذكاء الاصطناعي", "First section in Intro to Artificial Intelligence" },
                    { new Guid("15b40b3f-1104-4820-bb6d-7b14469fbe74"), new Guid("9d6d03c0-2bcb-47b4-ad8e-0fcfc3c3c04b"), false, "القسم الثاني في الهندسة المدنية المتقدمة", "Second section in Advanced Civil Engineering" },
                    { new Guid("15c2b701-7c07-4693-ba2b-6d6f140f7021"), new Guid("72dbc6b0-2f7e-4784-95e6-a276df58839f"), false, "القسم الأول في مقدمة في التعليم الإلكتروني", "First section in Intro to E-Learning" },
                    { new Guid("23dda834-b027-486d-ae10-1e04e408f7f1"), new Guid("df8699b0-8b9a-4be5-9639-20e2d9e48d33"), false, "القسم الأول في مبادئ الأمن السيبراني", "First section in Cyber Security Fundamentals" },
                    { new Guid("4673956b-854a-40c2-8532-75213e53b726"), new Guid("9d6d03c0-2bcb-47b4-ad8e-0fcfc3c3c04b"), false, "القسم الأول في الهندسة المدنية المتقدمة", "First section in Advanced Civil Engineering" },
                    { new Guid("5c259f7d-f647-451d-b8d4-f87286a1efcb"), new Guid("c5be303b-fc25-445d-a9bc-0c9351258ca8"), false, "القسم الثاني في أساسيات البرمجة", "Second section in Programming Basics" },
                    { new Guid("7b25cfcf-6459-4c63-a30a-465dff24a0b6"), new Guid("832cee7c-99e5-42ee-af2b-51aa1d3177d9"), false, "القسم الأول في أساسيات التسويق الرقمي", "First section in Digital Marketing Basics" },
                    { new Guid("8d6ff3d3-f1f8-47b7-8b43-bb5deb974341"), new Guid("56e357a1-bda0-412a-ad68-6ab234fe1502"), false, "القسم الأول في مبادئ الهندسة الميكانيكية", "First section in Mechanical Engineering Principles" },
                    { new Guid("9085060b-554a-4ce4-99d8-52cdbe3b718c"), new Guid("ca2f8ee4-68ea-4228-9f72-6179afef271c"), false, "القسم الثاني في أساسيات الفيزياء", "Second section in Physics Basics" },
                    { new Guid("a86274d0-f3b7-416d-a73f-74c1e8f0edcb"), new Guid("0bbc5774-c938-4b62-982e-f770be1c3882"), false, "القسم الثاني في تحليل البيانات المتقدم", "Second section in Advanced Data Analysis" },
                    { new Guid("ac44bc2b-ad6c-47d0-91fa-757478dbb7ec"), new Guid("49abba9b-2835-404d-afc6-8e0aba80be77"), false, "القسم الثاني في أساسيات الهندسة الكهربائية", "Second section in Electrical Engineering Basics" },
                    { new Guid("b7306cbf-30b2-42fb-a30b-bd487a27c5ce"), new Guid("df8699b0-8b9a-4be5-9639-20e2d9e48d33"), false, "القسم الثاني في مبادئ الأمن السيبراني", "Second section in Cyber Security Fundamentals" },
                    { new Guid("ccde33c0-0bfa-4da5-ac34-d37fa1f2891a"), new Guid("56e357a1-bda0-412a-ad68-6ab234fe1502"), false, "القسم الثاني في مبادئ الهندسة الميكانيكية", "Second section in Mechanical Engineering Principles" },
                    { new Guid("e04addeb-7437-4bdb-a8fb-28f67284d579"), new Guid("ca2f8ee4-68ea-4228-9f72-6179afef271c"), false, "القسم الأول في أساسيات الفيزياء", "First section in Physics Basics" },
                    { new Guid("efb63968-8e0e-4841-ac5e-41eccb9acc09"), new Guid("a3a9662f-4a77-406c-8171-2fcbb9bdd401"), false, "القسم الثاني في مقدمة في الذكاء الاصطناعي", "Second section in Intro to Artificial Intelligence" },
                    { new Guid("f2d0047e-8e14-4447-b421-0f94e15f9abf"), new Guid("832cee7c-99e5-42ee-af2b-51aa1d3177d9"), false, "القسم الثاني في أساسيات التسويق الرقمي", "Second section in Digital Marketing Basics" },
                    { new Guid("f8a6fa75-4bac-442e-a48b-74d7ed8a46cf"), new Guid("49abba9b-2835-404d-afc6-8e0aba80be77"), false, "القسم الأول في أساسيات الهندسة الكهربائية", "First section in Electrical Engineering Basics" },
                    { new Guid("fc754034-b186-4669-a402-d870df0ce730"), new Guid("c5be303b-fc25-445d-a9bc-0c9351258ca8"), false, "القسم الأول في أساسيات البرمجة", "First section in Programming Basics" }
                });

            migrationBuilder.InsertData(
                table: "UserInterstes",
                columns: new[] { "Id", "CourseId", "InterestsListId", "IsActive", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("c5be303b-fc25-445d-a9bc-0c9351258ca8"), null, false, new Guid("08cf98b1-41ed-4a48-affc-5f280b632070") },
                    { 2, new Guid("0bbc5774-c938-4b62-982e-f770be1c3882"), null, false, new Guid("aac40201-6f3f-4b45-881d-e734d742504e") },
                    { 3, new Guid("a3a9662f-4a77-406c-8171-2fcbb9bdd401"), null, false, new Guid("3f9ea1d3-54b2-46c8-b26b-188c2703828e") },
                    { 4, new Guid("df8699b0-8b9a-4be5-9639-20e2d9e48d33"), null, false, new Guid("5530ac02-7f1a-49a2-90fb-742bb873aa7d") },
                    { 5, new Guid("72dbc6b0-2f7e-4784-95e6-a276df58839f"), null, false, new Guid("0b7a7461-287a-4f8a-8668-92c8906c07ed") },
                    { 6, new Guid("832cee7c-99e5-42ee-af2b-51aa1d3177d9"), null, false, new Guid("5fd02879-31ea-487a-b68b-1700b3d27798") },
                    { 7, new Guid("49abba9b-2835-404d-afc6-8e0aba80be77"), null, false, new Guid("cf400225-260c-4e01-8f29-382f2b0cbfce") },
                    { 8, new Guid("56e357a1-bda0-412a-ad68-6ab234fe1502"), null, false, new Guid("94aa3d9b-c547-4ff9-8c10-c6de8a01b1a9") },
                    { 9, new Guid("9d6d03c0-2bcb-47b4-ad8e-0fcfc3c3c04b"), null, false, new Guid("14e78d9c-38d8-41a5-ad6d-771f27737d29") },
                    { 10, new Guid("ca2f8ee4-68ea-4228-9f72-6179afef271c"), null, false, new Guid("ef58cc66-522e-4f4a-83d2-de3778bc890f") }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ContentType", "FileUrl", "IsActive", "NameAr", "NameEn", "SectionId" },
                values: new object[,]
                {
                    { new Guid("09558227-27d1-4d02-af0e-3e9a4ffef7f4"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في أساسيات الفيزياء", "Second lesson in Second section in Physics Basics", new Guid("9085060b-554a-4ce4-99d8-52cdbe3b718c") },
                    { new Guid("09938257-b523-4331-aba5-476cce76d332"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في مبادئ الهندسة الميكانيكية", "First lesson in First section in Mechanical Engineering Principles", new Guid("8d6ff3d3-f1f8-47b7-8b43-bb5deb974341") },
                    { new Guid("159fec1c-6260-459e-b9d4-efcdec11ae1d"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في تحليل البيانات المتقدم", "Second lesson in Second section in Advanced Data Analysis", new Guid("a86274d0-f3b7-416d-a73f-74c1e8f0edcb") },
                    { new Guid("1c9102f4-18a6-41c4-9623-890762355c34"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في مبادئ الهندسة الميكانيكية", "First lesson in Second section in Mechanical Engineering Principles", new Guid("ccde33c0-0bfa-4da5-ac34-d37fa1f2891a") },
                    { new Guid("262649bf-f293-4efb-aa43-7ed296eda927"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في مبادئ الأمن السيبراني", "Second lesson in First section in Cyber Security Fundamentals", new Guid("23dda834-b027-486d-ae10-1e04e408f7f1") },
                    { new Guid("26c504a0-dda5-44d9-9003-34ff051d75c1"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في أساسيات الفيزياء", "First lesson in Second section in Physics Basics", new Guid("9085060b-554a-4ce4-99d8-52cdbe3b718c") },
                    { new Guid("2861e1ff-9fd0-4220-bd4a-7efbcb5d4725"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في مقدمة في التعليم الإلكتروني", "Second lesson in First section in Intro to E-Learning", new Guid("15c2b701-7c07-4693-ba2b-6d6f140f7021") },
                    { new Guid("2b551b02-88ad-46ce-ba00-07cfd0a6e06a"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في مبادئ الهندسة الميكانيكية", "Second lesson in First section in Mechanical Engineering Principles", new Guid("8d6ff3d3-f1f8-47b7-8b43-bb5deb974341") },
                    { new Guid("309ea4ff-9ade-45df-b85f-0f0201a28a34"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في مبادئ الأمن السيبراني", "First lesson in First section in Cyber Security Fundamentals", new Guid("23dda834-b027-486d-ae10-1e04e408f7f1") },
                    { new Guid("3ba88b50-6830-4420-8d19-6ab8894b434f"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في مبادئ الهندسة الميكانيكية", "Second lesson in Second section in Mechanical Engineering Principles", new Guid("ccde33c0-0bfa-4da5-ac34-d37fa1f2891a") },
                    { new Guid("4279bb8b-5a84-4ef6-9384-5018ada0ebc2"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في أساسيات البرمجة", "Second lesson in First section in Programming Basics", new Guid("fc754034-b186-4669-a402-d870df0ce730") },
                    { new Guid("4e5ddd32-83ba-4620-a36a-7380822eeb2e"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في أساسيات التسويق الرقمي", "Second lesson in Second section in Digital Marketing Basics", new Guid("f2d0047e-8e14-4447-b421-0f94e15f9abf") },
                    { new Guid("509287ee-a83b-4536-b060-8415d4e7096f"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في أساسيات الفيزياء", "Second lesson in First section in Physics Basics", new Guid("e04addeb-7437-4bdb-a8fb-28f67284d579") },
                    { new Guid("60f98055-ada3-4924-b3fe-0563ad0b87ff"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في مقدمة في التعليم الإلكتروني", "First lesson in First section in Intro to E-Learning", new Guid("15c2b701-7c07-4693-ba2b-6d6f140f7021") },
                    { new Guid("6be8f86b-34dd-4568-a733-3867a9f4aafc"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في الهندسة المدنية المتقدمة", "Second lesson in Second section in Advanced Civil Engineering", new Guid("15b40b3f-1104-4820-bb6d-7b14469fbe74") },
                    { new Guid("705a54aa-3544-44a6-9af8-d5d306f68d05"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في مبادئ الأمن السيبراني", "Second lesson in Second section in Cyber Security Fundamentals", new Guid("b7306cbf-30b2-42fb-a30b-bd487a27c5ce") },
                    { new Guid("7b665b0c-94db-4309-b76e-af356ff1e78d"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في تحليل البيانات المتقدم", "Second lesson in First section in Advanced Data Analysis", new Guid("09a0bb15-5df4-442b-83cf-65686a778168") },
                    { new Guid("826262cb-2486-43ee-87f8-5b256972eb49"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في مقدمة في التعليم الإلكتروني", "First lesson in Second section in Intro to E-Learning", new Guid("065a51f3-a037-4210-907b-4aeb89d268c7") },
                    { new Guid("88c25042-ed26-466a-9fb2-89bf06bc4bcf"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في تحليل البيانات المتقدم", "First lesson in First section in Advanced Data Analysis", new Guid("09a0bb15-5df4-442b-83cf-65686a778168") },
                    { new Guid("94a92ac2-8cb7-4000-b9d4-7e8452fa3ee1"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في مقدمة في الذكاء الاصطناعي", "Second lesson in First section in Intro to Artificial Intelligence", new Guid("1380a77d-2531-4935-b1a7-01e44f9a355f") },
                    { new Guid("9742b44b-d088-4a78-b192-a377322436e7"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في الهندسة المدنية المتقدمة", "First lesson in Second section in Advanced Civil Engineering", new Guid("15b40b3f-1104-4820-bb6d-7b14469fbe74") },
                    { new Guid("9818d9f4-f67b-486f-b78d-a5f1ab6388fc"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في أساسيات البرمجة", "First lesson in Second section in Programming Basics", new Guid("5c259f7d-f647-451d-b8d4-f87286a1efcb") },
                    { new Guid("9a73a813-d957-4c7f-89e5-217ede60f403"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في أساسيات الهندسة الكهربائية", "First lesson in First section in Electrical Engineering Basics", new Guid("f8a6fa75-4bac-442e-a48b-74d7ed8a46cf") },
                    { new Guid("9d36020a-e3d0-4802-bf40-1cfc8c656cfc"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في أساسيات التسويق الرقمي", "First lesson in Second section in Digital Marketing Basics", new Guid("f2d0047e-8e14-4447-b421-0f94e15f9abf") },
                    { new Guid("a47f2f6d-d36f-4aa3-9428-43b747389406"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في مقدمة في الذكاء الاصطناعي", "First lesson in Second section in Intro to Artificial Intelligence", new Guid("efb63968-8e0e-4841-ac5e-41eccb9acc09") },
                    { new Guid("bfd14491-553e-474e-a590-f6f62d105322"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في أساسيات الهندسة الكهربائية", "Second lesson in First section in Electrical Engineering Basics", new Guid("f8a6fa75-4bac-442e-a48b-74d7ed8a46cf") },
                    { new Guid("c1f5db40-3d9e-4f64-934e-7b1daa22dbb2"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في الهندسة المدنية المتقدمة", "Second lesson in First section in Advanced Civil Engineering", new Guid("4673956b-854a-40c2-8532-75213e53b726") },
                    { new Guid("c5b98d38-62f5-4a43-9cad-aa158da8c4a0"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في مبادئ الأمن السيبراني", "First lesson in Second section in Cyber Security Fundamentals", new Guid("b7306cbf-30b2-42fb-a30b-bd487a27c5ce") },
                    { new Guid("c711d942-590c-4797-af12-65ee62ad0f5d"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في مقدمة في الذكاء الاصطناعي", "First lesson in First section in Intro to Artificial Intelligence", new Guid("1380a77d-2531-4935-b1a7-01e44f9a355f") },
                    { new Guid("c9cfe415-d0de-4329-86d4-ffe6db7f34d8"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في أساسيات الهندسة الكهربائية", "First lesson in Second section in Electrical Engineering Basics", new Guid("ac44bc2b-ad6c-47d0-91fa-757478dbb7ec") },
                    { new Guid("cbb99df4-d6cf-4870-bc3f-19f5683e4f84"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في مقدمة في التعليم الإلكتروني", "Second lesson in Second section in Intro to E-Learning", new Guid("065a51f3-a037-4210-907b-4aeb89d268c7") },
                    { new Guid("cd19011e-a9dc-4ebc-a40f-67d76b469f3d"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الثاني في تحليل البيانات المتقدم", "First lesson in Second section in Advanced Data Analysis", new Guid("a86274d0-f3b7-416d-a73f-74c1e8f0edcb") },
                    { new Guid("d0cfb2ae-2d52-4b8d-8ac0-9033cadd5b84"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في أساسيات الهندسة الكهربائية", "Second lesson in Second section in Electrical Engineering Basics", new Guid("ac44bc2b-ad6c-47d0-91fa-757478dbb7ec") },
                    { new Guid("ded4f17f-a29e-4c4f-b89e-98a73e6d751f"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في مقدمة في الذكاء الاصطناعي", "Second lesson in Second section in Intro to Artificial Intelligence", new Guid("efb63968-8e0e-4841-ac5e-41eccb9acc09") },
                    { new Guid("f2be401d-d2f4-41ed-b359-cb624ab1af53"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في الهندسة المدنية المتقدمة", "First lesson in First section in Advanced Civil Engineering", new Guid("4673956b-854a-40c2-8532-75213e53b726") },
                    { new Guid("f5b14eaf-4daf-465e-81a2-87a6a4f858fb"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في أساسيات البرمجة", "First lesson in First section in Programming Basics", new Guid("fc754034-b186-4669-a402-d870df0ce730") },
                    { new Guid("f6ba1d08-a73f-4232-abab-bf1c219dfa44"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في أساسيات التسويق الرقمي", "First lesson in First section in Digital Marketing Basics", new Guid("7b25cfcf-6459-4c63-a30a-465dff24a0b6") },
                    { new Guid("f6e89544-ea32-47b0-85ac-28f8da4c44f9"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الأول في أساسيات التسويق الرقمي", "Second lesson in First section in Digital Marketing Basics", new Guid("7b25cfcf-6459-4c63-a30a-465dff24a0b6") },
                    { new Guid("fbb0fc15-40bb-4f7a-a988-16f3d90e49b5"), "Video", "https://example.com/lesson1.mp4", false, "الدرس الأول في القسم الأول في أساسيات الفيزياء", "First lesson in First section in Physics Basics", new Guid("e04addeb-7437-4bdb-a8fb-28f67284d579") },
                    { new Guid("fc0ad217-fd5e-4b60-b6f6-2c79f97cbda5"), "PDF", "https://example.com/lesson2.pdf", false, "الدرس الثاني في القسم الثاني في أساسيات البرمجة", "Second lesson in Second section in Programming Basics", new Guid("5c259f7d-f647-451d-b8d4-f87286a1efcb") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("020884ae-3139-4929-b1f4-0acba046f88a"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("03949101-1d7b-49cf-a575-364ad51707a8"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("08854305-81ca-41fb-a060-b063a2b5b2c1"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("0e1c832e-255d-47b1-9dc6-e03c23da1c45"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("11d6a90b-5e2b-4605-be20-108393cc476a"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("1c11ef7b-ebc3-4de2-9878-007744b0d50a"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("1e75961d-4321-4221-b064-d0363b619913"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("1f090b3e-1474-49bb-bcdd-6a1114dc26d0"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("29e5fba1-014b-4df1-9dfe-a22603130d91"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("3a01dd98-f0a4-49f2-9e2a-0f3c4971e78c"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("3dd73a64-6f78-4e7c-88b4-ca4d1e8a7886"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("49e04076-ea1d-4bd7-bf44-f449d2ee024d"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("548bb328-7d86-4072-bba5-0d6cb65cf8f8"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("5509de13-be01-41c5-a8d9-149f8d4ec49b"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("552fd439-53aa-4a9f-aeb4-695d59279a37"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("5966ba6c-96c8-4f24-a5a2-8c7a4d44717b"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("65896beb-b573-46dd-ac65-6fe48eb792e9"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("68bfffed-7357-4631-ade0-344bb5d3d18e"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("7a98e3b9-6b45-4a32-ac64-ff09deea02a2"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("8121fa6e-296e-49aa-970f-936b8db17860"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("88309015-d779-4a64-acc2-4cfa53f1a460"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("91ad6eb1-1ab4-48d1-985d-d368c590d228"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("9cf66ed9-5361-4e35-b961-736c0c04f46e"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("9e5dd471-6f05-434f-9175-77490920ed8f"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("9fccf490-85fe-4b0e-8594-8a8013b7d57c"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("a5694454-7fbc-4c34-9c97-aa6e33def9e8"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("a8b12a29-b077-46d7-91f9-ce36587dcfeb"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("a90ba18f-880d-4393-b5be-ee4a39791054"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("b0748877-7c7d-43a9-be0e-247a05b020dc"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("c00ddbf8-656c-4b07-a093-4400be39b2ee"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("c07c5a85-633f-4b0a-9aa4-7a4cb12846ee"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("c0b14ffe-7a00-4ef2-b21b-bb325936b578"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("cc35130e-c5d5-4a61-aaee-7b52b59350a0"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ce67fa4c-286f-4758-9de4-c336458b70b7"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("d0a1d44f-04cb-4305-9922-2110d7672517"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("d7273913-8f10-4dc9-9c25-50087c30ae17"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("e50a382e-8960-4fb0-b10f-a0a83ef9541a"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("e79dfd14-7c85-414b-b19e-23aac7a0f209"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("f4ef9b95-62cf-4eff-b987-e05310c06997"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("fbe57a7f-902c-49d2-bb1f-fca792914c22"));

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
                keyValue: new Guid("09558227-27d1-4d02-af0e-3e9a4ffef7f4"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("09938257-b523-4331-aba5-476cce76d332"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("159fec1c-6260-459e-b9d4-efcdec11ae1d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("1c9102f4-18a6-41c4-9623-890762355c34"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("262649bf-f293-4efb-aa43-7ed296eda927"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("26c504a0-dda5-44d9-9003-34ff051d75c1"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2861e1ff-9fd0-4220-bd4a-7efbcb5d4725"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2b551b02-88ad-46ce-ba00-07cfd0a6e06a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("309ea4ff-9ade-45df-b85f-0f0201a28a34"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("3ba88b50-6830-4420-8d19-6ab8894b434f"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("4279bb8b-5a84-4ef6-9384-5018ada0ebc2"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("4e5ddd32-83ba-4620-a36a-7380822eeb2e"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("509287ee-a83b-4536-b060-8415d4e7096f"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("60f98055-ada3-4924-b3fe-0563ad0b87ff"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("6be8f86b-34dd-4568-a733-3867a9f4aafc"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("705a54aa-3544-44a6-9af8-d5d306f68d05"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("7b665b0c-94db-4309-b76e-af356ff1e78d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("826262cb-2486-43ee-87f8-5b256972eb49"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("88c25042-ed26-466a-9fb2-89bf06bc4bcf"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("94a92ac2-8cb7-4000-b9d4-7e8452fa3ee1"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9742b44b-d088-4a78-b192-a377322436e7"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9818d9f4-f67b-486f-b78d-a5f1ab6388fc"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9a73a813-d957-4c7f-89e5-217ede60f403"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9d36020a-e3d0-4802-bf40-1cfc8c656cfc"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("a47f2f6d-d36f-4aa3-9428-43b747389406"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("bfd14491-553e-474e-a590-f6f62d105322"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c1f5db40-3d9e-4f64-934e-7b1daa22dbb2"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c5b98d38-62f5-4a43-9cad-aa158da8c4a0"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c711d942-590c-4797-af12-65ee62ad0f5d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c9cfe415-d0de-4329-86d4-ffe6db7f34d8"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("cbb99df4-d6cf-4870-bc3f-19f5683e4f84"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("cd19011e-a9dc-4ebc-a40f-67d76b469f3d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d0cfb2ae-2d52-4b8d-8ac0-9033cadd5b84"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ded4f17f-a29e-4c4f-b89e-98a73e6d751f"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f2be401d-d2f4-41ed-b359-cb624ab1af53"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f5b14eaf-4daf-465e-81a2-87a6a4f858fb"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f6ba1d08-a73f-4232-abab-bf1c219dfa44"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f6e89544-ea32-47b0-85ac-28f8da4c44f9"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("fbb0fc15-40bb-4f7a-a988-16f3d90e49b5"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("fc0ad217-fd5e-4b60-b6f6-2c79f97cbda5"));

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
                keyValue: new Guid("0706a5b2-01e9-4bec-8c42-68dd382adb00"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("0905d706-2d5f-46cc-98e1-b8199ea4ed1f"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("0da48415-7c80-403b-ae00-e6167c7abfc6"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("185df395-22cb-4ef7-90ca-1ae526a07656"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("293a93de-1b39-4ab1-a497-3e1871593bb2"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("32aef844-1b6e-4521-a775-06433ce50133"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("4f448d6d-7eec-42d2-b44f-95fae2256011"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("5704d6d5-913d-4d69-aa5c-ac0f0dd9c8db"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("5f543fef-fbd9-44fc-82fe-cb46b7234a54"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("821bd343-34cb-46c3-9a23-c1368ed30032"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("83739f63-4b59-42ea-9f0e-f05742d8e965"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("83e2d83b-ff9a-4931-bcc8-010e1951aae9"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("8bf93b3a-5521-4bba-9d07-cbc4d7747b71"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("a5f1fd3f-cb3b-44b2-8d8c-e03ad693720f"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("c46a057a-3e34-4eee-906e-c53fe957d808"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("d03eb6af-a058-42be-80e8-f33414004104"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("d1d58918-7cec-4f60-9d8e-9bd8e316dc49"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("d37420c4-c5d8-4bf4-a0d4-e5c2089869b0"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("efe30e31-9ba3-4ea8-b7f1-a246c9ced7f7"));

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: new Guid("f27a1b67-1262-4aad-bb5d-0f3449b4439f"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("065a51f3-a037-4210-907b-4aeb89d268c7"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("09a0bb15-5df4-442b-83cf-65686a778168"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("1380a77d-2531-4935-b1a7-01e44f9a355f"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("15b40b3f-1104-4820-bb6d-7b14469fbe74"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("15c2b701-7c07-4693-ba2b-6d6f140f7021"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("23dda834-b027-486d-ae10-1e04e408f7f1"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("4673956b-854a-40c2-8532-75213e53b726"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("5c259f7d-f647-451d-b8d4-f87286a1efcb"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("7b25cfcf-6459-4c63-a30a-465dff24a0b6"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("8d6ff3d3-f1f8-47b7-8b43-bb5deb974341"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("9085060b-554a-4ce4-99d8-52cdbe3b718c"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("a86274d0-f3b7-416d-a73f-74c1e8f0edcb"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("ac44bc2b-ad6c-47d0-91fa-757478dbb7ec"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("b7306cbf-30b2-42fb-a30b-bd487a27c5ce"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("ccde33c0-0bfa-4da5-ac34-d37fa1f2891a"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("e04addeb-7437-4bdb-a8fb-28f67284d579"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("efb63968-8e0e-4841-ac5e-41eccb9acc09"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("f2d0047e-8e14-4447-b421-0f94e15f9abf"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("f8a6fa75-4bac-442e-a48b-74d7ed8a46cf"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("fc754034-b186-4669-a402-d870df0ce730"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("08cf98b1-41ed-4a48-affc-5f280b632070"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b7a7461-287a-4f8a-8668-92c8906c07ed"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("14e78d9c-38d8-41a5-ad6d-771f27737d29"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f9ea1d3-54b2-46c8-b26b-188c2703828e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5530ac02-7f1a-49a2-90fb-742bb873aa7d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5fd02879-31ea-487a-b68b-1700b3d27798"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("94aa3d9b-c547-4ff9-8c10-c6de8a01b1a9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aac40201-6f3f-4b45-881d-e734d742504e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf400225-260c-4e01-8f29-382f2b0cbfce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ef58cc66-522e-4f4a-83d2-de3778bc890f"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("0bbc5774-c938-4b62-982e-f770be1c3882"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("49abba9b-2835-404d-afc6-8e0aba80be77"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("56e357a1-bda0-412a-ad68-6ab234fe1502"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("72dbc6b0-2f7e-4784-95e6-a276df58839f"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("832cee7c-99e5-42ee-af2b-51aa1d3177d9"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("9d6d03c0-2bcb-47b4-ad8e-0fcfc3c3c04b"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a3a9662f-4a77-406c-8171-2fcbb9bdd401"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("c5be303b-fc25-445d-a9bc-0c9351258ca8"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("ca2f8ee4-68ea-4228-9f72-6179afef271c"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("df8699b0-8b9a-4be5-9639-20e2d9e48d33"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("0031e422-a013-41c6-ba5f-14bac83b55af"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("09463ad4-d48a-424e-8e1d-66fd11d069a8"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("298d44bf-6d3c-4095-aff3-c1fd86d7bad0"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("486ec9eb-3a2d-4b29-b4dd-892accb188ec"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("aaf6723f-4dc3-4971-a7fa-e5b597580d69"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("bd47ddec-9d65-4331-a8fc-e8490d3a9042"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("d4648f3d-0413-4e93-8145-ba686c630b3e"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("d7bb4edf-86e1-408d-936d-4398f6ae1abe"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("e8df9a64-3e8e-48b2-9cff-166a92fa409e"));

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: new Guid("ed347594-f1d0-4228-b293-d96cf7a447c1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1210ad0c-0043-47bb-9543-ffe58cd6c3a6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4ba2a722-5622-4b9f-a386-8db07c865c2c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("591d5b94-cb3d-4c47-8fd7-62dccb6ab239"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63464890-61ee-4906-8010-5833ea62bd08"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("83f11885-011f-4fb1-90e6-35f1098352c9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aca856cb-bb73-4370-a971-c8fc5103c519"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2d96a13-883b-435a-bdb2-562be473371d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f613a892-3833-4ba3-9e80-a4ca965c42d4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f87b222f-c457-47ac-9a71-d1ce6813af62"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fb4ca459-47f5-4619-a6e7-45d17c9bb3f0"));

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
                keyValue: new Guid("0c09e037-1c0e-44f5-847a-9d6843047a47"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("0d95f453-c111-4b67-b884-322d8e4cb89d"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3bad6969-0481-4d1e-9d78-ebf8e1d60b3c"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("777da8e0-8571-446c-9ed1-08d365ed3a93"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("9c9dec31-2568-45d2-93e2-b0bd997cf157"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("a17b04ef-f261-4089-b63b-6d512ff7664f"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("bba9319e-cfa3-4e49-806c-aec8a108af88"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("be2f5b63-7ac1-49d4-ae66-312445025b18"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d0c66db6-8b86-4dd2-8852-19baee3b7f3c"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("ed20f329-4daf-4cdf-ba3d-9d129345ac24"));

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
        }
    }
}
