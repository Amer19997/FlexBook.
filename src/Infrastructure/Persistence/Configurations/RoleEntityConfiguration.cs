using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
{
    public  void Configure(EntityTypeBuilder<Role> builder)
    {
       
        builder.OwnsOne(s => s.Name, x =>
        {
            x.Property(n => n.DescriptionAr)
            .HasColumnName("NameAr")
            .IsRequired()
            .HasMaxLength(50);

            x.Property(n => n.DescriptionEn)
            .HasColumnName("NameEn")
            .IsRequired()
            .HasMaxLength(50);
        });
        
    }
}