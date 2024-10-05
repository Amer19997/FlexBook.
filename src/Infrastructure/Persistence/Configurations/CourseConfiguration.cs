using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.NameAr).IsRequired().HasMaxLength(150);
        builder.Property(c => c.NameEn).IsRequired().HasMaxLength(150);
        builder.Property(c => c.DiscriptionAr).HasMaxLength(500);
        builder.Property(c => c.DiscriptionEn).HasMaxLength(500);

        // Category relationship - Cascade delete is allowed here
        builder.HasOne(c => c.Category)
               .WithMany(c => c.Courses)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

        // Topic relationship - Use Restrict to avoid multiple cascade paths
        builder.HasOne(c => c.Topic)
               .WithMany(t => t.Courses)
               .HasForeignKey(c => c.TopicId)
               .OnDelete(DeleteBehavior.Restrict); // No cascading on delete

        // Sections relationship - Cascade delete
        builder.HasMany(c => c.Sections)
               .WithOne(s => s.Course)
               .HasForeignKey(s => s.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
