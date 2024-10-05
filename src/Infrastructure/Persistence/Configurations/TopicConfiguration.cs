using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlexBook.Infrastructure.Persistence.Configurations;
public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("Topics");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.NameAr).IsRequired().HasMaxLength(100);
        builder.Property(t => t.NameEn).IsRequired().HasMaxLength(100);
        builder.HasMany(t => t.Categories)
               .WithOne(c => c.Topic)
               .HasForeignKey(c => c.TopicId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(t => t.Courses)
               .WithOne(c => c.Topic)
               .HasForeignKey(c => c.TopicId);
               
    }
}