using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(m => m.CMSSection)
               .WithMany(m => m.PermissionList)
               .HasForeignKey(m => m.CMSSectionId);


    }
}
