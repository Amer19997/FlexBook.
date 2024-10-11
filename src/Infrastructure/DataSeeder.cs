using System;
using System.Collections.Generic;
using FlexBook.Domain.Entities;
using FlexBook.Domain.Entities.Authorization;
using FlexBook.Domain.Entities.Catalog;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlexBook.Infrastructure;

public static class DataSeeder
{
    // Load the configuration using ConfigurationManager


    public static void Seed(ModelBuilder modelBuilder, IConfiguration configuration)
    {
        // Access the dynamic BaseImageUrl from the configuration
        string baseImageUrl = configuration["AppSettings:FileSettings:BaseImageUrl"];

        // Seeding Countries
        var countries = new List<Country>
            {
                new Country { Id = 1, NameAr = "الولايات المتحدة", NameEn = "United States" },
                new Country { Id = 2, NameAr = "المملكة المتحدة", NameEn = "United Kingdom" },
                new Country { Id = 3, NameAr = "كندا", NameEn = "Canada" },
                new Country { Id = 4, NameAr = "أستراليا", NameEn = "Australia" },
                new Country { Id = 5, NameAr = "الهند", NameEn = "India" },
                new Country { Id = 6, NameAr = "ألمانيا", NameEn = "Germany" },
                new Country { Id = 7, NameAr = "البرازيل", NameEn = "Brazil" },
                new Country { Id = 8, NameAr = "اليابان", NameEn = "Japan" },
                new Country { Id = 9, NameAr = "فرنسا", NameEn = "France" },
                new Country { Id = 10, NameAr = "الإمارات العربية المتحدة", NameEn = "United Arab Emirates" }
            };
            modelBuilder.Entity<Country>().HasData(countries);

            // Seeding Universities
            var universities = new List<University>();
            for (int i = 1; i <= 10; i++)
            {
                universities.Add(new University
                {
                    Id = Guid.NewGuid(),
                    NameAr = $"جامعة {countries[i - 1].NameAr}",
                    NameEn = $"University of {countries[i - 1].NameEn}",
                    LookUpStatus = LookUpStatus.Active,
                    CountryId = i
                });
            }
            modelBuilder.Entity<University>().HasData(universities);

            // Seeding Faculties
            var faculties = new List<Faculty>();
            foreach (var university in universities)
            {
                faculties.Add(new Faculty
                {
                    Id = Guid.NewGuid(),
                    NameAr = $"كلية الهندسة في {university.NameAr}",
                    NameEn = $"Faculty of Engineering in {university.NameEn}",
                    LookUpStatus = LookUpStatus.Active,
                    UniversityId = university.Id
                });
                faculties.Add(new Faculty
                {
                    Id = Guid.NewGuid(),
                    NameAr = $"كلية العلوم في {university.NameAr}",
                    NameEn = $"Faculty of Science in {university.NameEn}",
                    LookUpStatus = LookUpStatus.Active,
                    UniversityId = university.Id
                });
            }
            modelBuilder.Entity<Faculty>().HasData(faculties);

            // Seeding Departments
            var departments = new List<Department>();
            foreach (var faculty in faculties)
            {
                departments.Add(new Department
                {
                    Id = Guid.NewGuid(),
                    NameAr = $"قسم علوم الحاسوب في {faculty.NameAr}",
                    NameEn = $"Department of Computer Science in {faculty.NameEn}",
                    LookUpStatus = LookUpStatus.Active,
                    FacultyId = faculty.Id
                });
                departments.Add(new Department
                {
                    Id = Guid.NewGuid(),
                    NameAr = $"قسم الفيزياء في {faculty.NameAr}",
                    NameEn = $"Department of Physics in {faculty.NameEn}",
                    LookUpStatus = LookUpStatus.Active,
                    FacultyId = faculty.Id
                });
            }
            modelBuilder.Entity<Department>().HasData(departments);

            // Seeding InterestsList
            var interests = new List<InterestsList>
            {
                new InterestsList { Id = 1, NameAr = "الذكاء الاصطناعي", NameEn = "Artificial Intelligence" },
                new InterestsList { Id = 2, NameAr = "تطوير الويب", NameEn = "Web Development" },
                new InterestsList { Id = 3, NameAr = "تحليل البيانات", NameEn = "Data Analysis" },
                new InterestsList { Id = 4, NameAr = "تعلم الآلة", NameEn = "Machine Learning" },
                new InterestsList { Id = 5, NameAr = "الأمن السيبراني", NameEn = "Cyber Security" },
                new InterestsList { Id = 6, NameAr = "إدارة الأعمال", NameEn = "Business Management" },
                new InterestsList { Id = 7, NameAr = "البرمجة", NameEn = "Programming" },
                new InterestsList { Id = 8, NameAr = "الفيزياء", NameEn = "Physics" },
                new InterestsList { Id = 9, NameAr = "الهندسة المدنية", NameEn = "Civil Engineering" },
                new InterestsList { Id = 10, NameAr = "التصميم الجرافيكي", NameEn = "Graphic Design" }
            };
            modelBuilder.Entity<InterestsList>().HasData(interests);

            // Seeding Topics
            var topics = new List<Topic>
            {
                new Topic { Id = Guid.NewGuid(), NameAr = "تطوير البرمجيات", NameEn = "Software Development" },
                new Topic { Id = Guid.NewGuid(), NameAr = "تحليل البيانات", NameEn = "Data Analysis" },
                new Topic { Id = Guid.NewGuid(), NameAr = "الذكاء الاصطناعي", NameEn = "Artificial Intelligence" },
                new Topic { Id = Guid.NewGuid(), NameAr = "الأمن السيبراني", NameEn = "Cyber Security" },
                new Topic { Id = Guid.NewGuid(), NameAr = "التعليم الإلكتروني", NameEn = "E-Learning" },
                new Topic { Id = Guid.NewGuid(), NameAr = "التسويق الرقمي", NameEn = "Digital Marketing" },
                new Topic { Id = Guid.NewGuid(), NameAr = "الهندسة الكهربائية", NameEn = "Electrical Engineering" },
                new Topic { Id = Guid.NewGuid(), NameAr = "الهندسة الميكانيكية", NameEn = "Mechanical Engineering" },
                new Topic { Id = Guid.NewGuid(), NameAr = "الهندسة المدنية", NameEn = "Civil Engineering" },
                new Topic { Id = Guid.NewGuid(), NameAr = "العلوم الفيزيائية", NameEn = "Physical Sciences" }
            };
            modelBuilder.Entity<Topic>().HasData(topics);

            // Seeding Categories
            var categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), NameAr = "برمجة", NameEn = "Programming", TopicId = topics[0].Id },
                new Category { Id = Guid.NewGuid(), NameAr = "تحليل البيانات", NameEn = "Data Analysis", TopicId = topics[1].Id },
                new Category { Id = Guid.NewGuid(), NameAr = "ذكاء اصطناعي", NameEn = "Artificial Intelligence", TopicId = topics[2].Id },
                new Category { Id = Guid.NewGuid(), NameAr = "أمن سيبراني", NameEn = "Cyber Security", TopicId = topics[3].Id },
                new Category { Id = Guid.NewGuid(), NameAr = "تعليم إلكتروني", NameEn = "E-Learning", TopicId = topics[4].Id },
                new Category { Id = Guid.NewGuid(), NameAr = "تسويق رقمي", NameEn = "Digital Marketing", TopicId = topics[5].Id },
                new Category { Id = Guid.NewGuid(), NameAr = "هندسة كهربائية", NameEn = "Electrical Engineering", TopicId = topics[6].Id },
                new Category { Id = Guid.NewGuid(), NameAr = "هندسة ميكانيكية", NameEn = "Mechanical Engineering", TopicId = topics[7].Id },
                new Category { Id = Guid.NewGuid(), NameAr = "هندسة مدنية", NameEn = "Civil Engineering", TopicId = topics[8].Id },
                new Category { Id = Guid.NewGuid(), NameAr = "علوم فيزيائية", NameEn = "Physical Sciences", TopicId = topics[9].Id }
            };
            modelBuilder.Entity<Category>().HasData(categories);

            // Seeding Courses
            var courses = new List<Course>
            {
                new Course { Id = Guid.NewGuid(), NameAr = "أساسيات البرمجة", NameEn = "Programming Basics", DiscriptionAr = "دورة تعلم أساسيات البرمجة", DiscriptionEn = "Learn the basics of programming", CategoryId = categories[0].Id, TopicId = topics[0].Id, CoverPhoto = $"{baseImageUrl}data_analysis.jpg" },
                new Course { Id = Guid.NewGuid(), NameAr = "تحليل البيانات المتقدم", NameEn = "Advanced Data Analysis", DiscriptionAr = "دورة تعلم تحليل البيانات المتقدم", DiscriptionEn = "Learn advanced data analysis", CategoryId = categories[1].Id, TopicId = topics[1].Id, CoverPhoto = $"{baseImageUrl}data_analysis.jpg"   },
                new Course { Id = Guid.NewGuid(), NameAr = "مقدمة في الذكاء الاصطناعي", NameEn = "Intro to Artificial Intelligence", DiscriptionAr = "دورة مقدمة في الذكاء الاصطناعي", DiscriptionEn = "Introduction to Artificial Intelligence", CategoryId = categories[2].Id, TopicId = topics[2].Id, CoverPhoto = $"{baseImageUrl}data_analysis.jpg"   },
                new Course { Id = Guid.NewGuid(), NameAr = "مبادئ الأمن السيبراني", NameEn = "Cyber Security Fundamentals", DiscriptionAr = "دورة تعلم مبادئ الأمن السيبراني", DiscriptionEn = "Learn the fundamentals of cyber security", CategoryId = categories[3].Id, TopicId = topics[3].Id, CoverPhoto = $"{baseImageUrl}data_analysis.jpg"   },
                new Course { Id = Guid.NewGuid(), NameAr = "مقدمة في التعليم الإلكتروني", NameEn = "Intro to E-Learning", DiscriptionAr = "دورة تعلم مبادئ التعليم الإلكتروني", DiscriptionEn = "Introduction to e-learning", CategoryId = categories[4].Id, TopicId = topics[4].Id, CoverPhoto = $"{baseImageUrl}data_analysis.jpg"   },
                new Course { Id = Guid.NewGuid(), NameAr = "أساسيات التسويق الرقمي", NameEn = "Digital Marketing Basics", DiscriptionAr = "دورة تعلم أساسيات التسويق الرقمي", DiscriptionEn = "Learn the basics of digital marketing", CategoryId = categories[5].Id, TopicId = topics[5].Id, CoverPhoto = $"{baseImageUrl}data_analysis.jpg"   },
                new Course { Id = Guid.NewGuid(), NameAr = "أساسيات الهندسة الكهربائية", NameEn = "Electrical Engineering Basics", DiscriptionAr = "دورة تعلم أساسيات الهندسة الكهربائية", DiscriptionEn = "Learn the basics of electrical engineering", CategoryId = categories[6].Id, TopicId = topics[6].Id,CoverPhoto = $"{baseImageUrl}data_analysis.jpg"   },
                new Course { Id = Guid.NewGuid(), NameAr = "مبادئ الهندسة الميكانيكية", NameEn = "Mechanical Engineering Principles", DiscriptionAr = "دورة تعلم مبادئ الهندسة الميكانيكية", DiscriptionEn = "Learn the principles of mechanical engineering", CategoryId = categories[7].Id, TopicId = topics[7].Id, CoverPhoto = $"{baseImageUrl}data_analysis.jpg" },
                new Course { Id = Guid.NewGuid(), NameAr = "الهندسة المدنية المتقدمة", NameEn = "Advanced Civil Engineering", DiscriptionAr = "دورة تعلم الهندسة المدنية المتقدمة", DiscriptionEn = "Learn advanced civil engineering", CategoryId = categories[8].Id, TopicId = topics[8].Id, CoverPhoto = $"{baseImageUrl}data_analysis.jpg"   },
                new Course { Id = Guid.NewGuid(), NameAr = "أساسيات الفيزياء", NameEn = "Physics Basics", DiscriptionAr = "دورة تعلم أساسيات الفيزياء", DiscriptionEn = "Learn the basics of physics", CategoryId = categories[9].Id, TopicId = topics[9].Id, CoverPhoto = "physics_basics.jpg" }
            };
            modelBuilder.Entity<Course>().HasData(courses);

            // Seeding Sections
            var sections = new List<Section>();
            foreach (var course in courses)
            {
                sections.Add(new Section
                {
                    Id = Guid.NewGuid(),
                    TitleAr = $"القسم الأول في {course.NameAr}",
                    TitleEn = $"First section in {course.NameEn}",
                    CourseId = course.Id
                });
                sections.Add(new Section
                {
                    Id = Guid.NewGuid(),
                    TitleAr = $"القسم الثاني في {course.NameAr}",
                    TitleEn = $"Second section in {course.NameEn}",
                    CourseId = course.Id
                });
            }
            modelBuilder.Entity<Section>().HasData(sections);

            // Seeding Lessons
            var lessons = new List<Lesson>();
            foreach (var section in sections)
            {
                lessons.Add(new Lesson
                {
                    Id = Guid.NewGuid(),
                    NameAr = $"الدرس الأول في {section.TitleAr}",
                    NameEn = $"First lesson in {section.TitleEn}",
                    ContentType = "Video",
                    FileUrl = "https://example.com/lesson1.mp4",
                    SectionId = section.Id
                });
                lessons.Add(new Lesson
                {
                    Id = Guid.NewGuid(),
                    NameAr = $"الدرس الثاني في {section.TitleAr}",
                    NameEn = $"Second lesson in {section.TitleEn}",
                    ContentType = "PDF",
                    FileUrl = "https://example.com/lesson2.pdf",
                    SectionId = section.Id
                });
            }
            modelBuilder.Entity<Lesson>().HasData(lessons);
            var roles = new List<Role>
            {
                new Role { Id = Guid.NewGuid(), Name = "Admin" },
                new Role { Id = Guid.NewGuid(), Name = "User" },
                new Role { Id = Guid.NewGuid(), Name = "Manager" }
            };

            modelBuilder.Entity<Role>().HasData(roles);

            // Seeding Permissions
            // Seeding Permissions
            var permissions = new List<Permission>
{
             new Permission("Create", "Books"),
            new Permission("Edit", "Books"),
            new Permission("Delete", "Books"),
            new Permission("Create", "Users"),
            new Permission("Edit", "Users"),
            new Permission("Delete", "Users"),
};

            modelBuilder.Entity<Permission>().HasData(permissions);

            // Seeding RolePermissions (many-to-many relationship between Roles and Permissions)
            var rolePermissions = new List<RolePermission>
            {
                // Admin has all permissions
                new RolePermission { RoleId = roles[0].Id, PermissionId = permissions[0].Id },
                new RolePermission { RoleId = roles[0].Id, PermissionId = permissions[1].Id },
                new RolePermission { RoleId = roles[0].Id, PermissionId = permissions[2].Id },

                // Manager has Create and Edit permissions
                new RolePermission { RoleId = roles[2].Id, PermissionId = permissions[0].Id },
                new RolePermission { RoleId = roles[2].Id, PermissionId = permissions[1].Id },

                // User only has View permissions (assumed if needed)
            };

            modelBuilder.Entity<RolePermission>().HasData(rolePermissions);

            // Seeding Users
            var users = new List<User>();
            for (int i = 1; i <= 10; i++)
            {
                var role = roles[i % roles.Count];  // Assign roles in a cyclic manner

                users.Add(new User(
                    Guid.NewGuid(),                      // Unique user ID
                    $"User{i}",                          // First Name
                    $"LastName{i}",                      // Last Name
                    $"123456789{i}",                     // Mobile Number
                    $"user{i}@example.com",              // Email
                    DateTimeOffset.Now,                  // Registration Date
                    UserStatus.Active,                   // User Status
                    i % 10 + 1,                          // Country ID (cycling through 10 countries)
                    null,                                // No University ID (optional)
                    null,                                // No Faculty ID (optional)
                    null,                                // No Department ID (optional)
                    UserTypeEnum.Student,                // User Type (Student)
                    $"password{i}"                       // Password
                )
                {
                    RoleId = role.Id                     // Assigning a RoleId from the seeded roles
                });
            }
            //// Seeding Users
            //var users = new List<User>();
            //for (int i = 1; i <= 10; i++)
            //{
            //    users.Add(new User(
            //        Guid.NewGuid(),
            //        $"User{i}",
            //        $"LastName{i}",
            //        $"123456789{i}",
            //        $"user{i}@example.com",
            //        DateTimeOffset.Now,
            //        UserStatus.Active,
            //        i % 10 + 1,   // Assigning each user to one of the 10 countries
            //        null, null, null, // No university/faculty/department assignment
            //        UserTypeEnum.Student,
            //        $"password{i}"
            //    ));
            //}
            modelBuilder.Entity<User>().HasData(users);

            // Seeding UserInterests
            var userInterests = new List<UserInterstes>();
            for (int i = 0; i < 10; i++)
            {
                userInterests.Add(new UserInterstes
                {
                    Id = i + 1,
                    UserId = users[i].Id,
                    CourseId = courses[i].Id // Linking users to a course
                });
            }
            modelBuilder.Entity<UserInterstes>().HasData(userInterests);
        }
    }
