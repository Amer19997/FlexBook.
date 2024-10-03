using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Email)
            .IsUnique(true);

        builder.Property(_ => _.FirstName)
           .IsRequired()
           .HasMaxLength(100);

        builder.Property(_ => _.LastName)
          .IsRequired()
          .HasMaxLength(100);

        builder.Property(_ => _.Email)
           .IsRequired()
           .HasMaxLength(100);

        builder.Property(_ => _.Password)
           .IsRequired(false)
        .HasMaxLength(200);


        builder.HasOne(m=>m.Country)
               .WithMany(m=>m.UserList)
               .HasForeignKey(x => x.CountryId);

        builder.HasOne(m => m.University)
               .WithMany(m => m.UserList)
               .HasForeignKey(x => x.UniversityId);

        builder.HasOne(m => m.Faculty)
               .WithMany(m => m.UserList)
               .HasForeignKey(x => x.FacultyId);

        builder.HasOne(m => m.Department)
               .WithMany(m => m.UserList)
               .HasForeignKey(x => x.DepartmentId);

        builder.Property(n => n.MobileNumber)
        .HasColumnName("MobileNumber")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(n => n.IsSuperAdmin)
            .HasDefaultValue(false);
    }
}
