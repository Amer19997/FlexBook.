using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
{
    public void Configure(EntityTypeBuilder<UserType> builder)
    {
       
        builder.ToTable("UserTypes");



    }
}
