using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class UserInterstesConfiguration : IEntityTypeConfiguration<UserInterstes>
{
    public void Configure(EntityTypeBuilder<UserInterstes> builder)
    {
        builder.HasKey(m => m.Id);
        builder.HasOne(m => m.User)
               .WithMany(m => m.UserInterstesList)
               .HasForeignKey(m => m.UserId);

        builder.HasOne(m => m.Course)
               .WithMany(m => m.UserInterstesList)
               .HasForeignKey(m => m.CourseId);

    }
}
