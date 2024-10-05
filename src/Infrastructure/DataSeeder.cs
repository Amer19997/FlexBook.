using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.Catalog;
using FlexBook.Domain.Entities.LookUps;
using Microsoft.EntityFrameworkCore;

namespace FlexBook.Infrastructure;
public static class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Seeding Topics
        var topic1Id = Guid.NewGuid();
        var topic2Id = Guid.NewGuid();
        modelBuilder.Entity<Topic>().HasData(
            new Topic
            {
                Id = topic1Id,
                NameAr = "الموضوع الأول",
                NameEn = "Topic 1"
            },
            new Topic
            {
                Id = topic2Id,
                NameAr = "الموضوع الثاني",
                NameEn = "Topic 2"
            }
        );

        // Seeding Categories with reference to Topic
        var category1Id = Guid.NewGuid();
        var category2Id = Guid.NewGuid();
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = category1Id,
                NameAr = "الفئة الأولى",
                NameEn = "Category 1",
                TopicId = topic1Id
            },
            new Category
            {
                Id = category2Id,
                NameAr = "الفئة الثانية",
                NameEn = "Category 2",
                TopicId = topic2Id
            }
        );

        // Seeding Courses (linked to Categories and Topics)
        var course1Id = Guid.NewGuid();
        var course2Id = Guid.NewGuid();
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = course1Id,
                NameAr = "الدورة الأولى",
                NameEn = "Course 1",
                DiscriptionAr = "وصف الدورة الأولى",
                DiscriptionEn = "Description of Course 1",
                CategoryId = category1Id,
                TopicId = topic1Id,
                CoverPhoto = "cover1.jpg"
            },
            new Course
            {
                Id = course2Id,
                NameAr = "الدورة الثانية",
                NameEn = "Course 2",
                DiscriptionAr = "وصف الدورة الثانية",
                DiscriptionEn = "Description of Course 2",
                CategoryId = category2Id,
                TopicId = topic2Id,
                CoverPhoto = "cover2.jpg"
            }
        );

        // Seeding Sections (linked to Courses)
        var section1Id = Guid.NewGuid();
        var section2Id = Guid.NewGuid();
        modelBuilder.Entity<Section>().HasData(
            new Section
            {
                Id = section1Id,
                TitleAr = "القسم الأول",
                TitleEn = "Section 1",
                CourseId = course1Id
            },
            new Section
            {
                Id = section2Id,
                TitleAr = "القسم الثاني",
                TitleEn = "Section 2",
                CourseId = course2Id
            }
        );

        // Seeding Lessons (linked to Sections)
        modelBuilder.Entity<Lesson>().HasData(
            new Lesson
            {
                Id = Guid.NewGuid(),
                NameAr = "الدرس الأول",
                NameEn = "Lesson 1",
                ContentType = "Video",
                FileUrl = "https://example.com/video1.mp4",
                SectionId = section1Id
            },
            new Lesson
            {
                Id = Guid.NewGuid(),
                NameAr = "الدرس الثاني",
                NameEn = "Lesson 2",
                ContentType = "PDF",
                FileUrl = "https://example.com/lesson2.pdf",
                SectionId = section1Id
            },
            new Lesson
            {
                Id = Guid.NewGuid(),
                NameAr = "الدرس الثالث",
                NameEn = "Lesson 3",
                ContentType = "Video",
                FileUrl = "https://example.com/video3.mp4",
                SectionId = section2Id
            }
        );
    }
}