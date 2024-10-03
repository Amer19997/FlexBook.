using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(m => m.Permission)
               .WithMany(m => m.RolePermissionList)
               .HasForeignKey(m => m.permissionId);



        builder.HasOne(m => m.Role)
               .WithMany(m => m.RolePermissionList)
               .HasForeignKey(m => m.RoleId);
    }
}
