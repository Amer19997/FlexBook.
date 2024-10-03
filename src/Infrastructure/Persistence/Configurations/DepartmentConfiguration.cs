using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(m => m.Faculty)
               .WithMany(m => m.DepartmentList)
               .HasForeignKey(m => m.FacultyId);
    }
}
