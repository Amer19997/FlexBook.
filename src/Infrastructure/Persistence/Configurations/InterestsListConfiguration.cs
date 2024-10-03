using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class InterestsListConfiguration : IEntityTypeConfiguration<InterestsList>
{
    public void Configure(EntityTypeBuilder<InterestsList> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
