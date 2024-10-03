using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Infrastructure.Persistence.Configurations
{
    public class CMSSectionsConfiguration : IEntityTypeConfiguration<CMSSections>
    {
        public void Configure(EntityTypeBuilder<CMSSections> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
