using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FlexBook.Domain.Common;

namespace FlexBook.Infrastructure.Persistence;

public abstract class DomainEntityConfiguration<T, TKey> : IEntityTypeConfiguration<T>
    where T : DomainEntity<TKey>
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.HasKey(c => c.Id);
    }
}

public abstract class DomainEntityWithValidatorConfiguration<T, TKey> : DomainEntityConfiguration<T, TKey>
    where T : DomainEntity<T, TKey>
{
    public override void Configure(EntityTypeBuilder<T> entity)
    {
        base.Configure(entity);

        entity.Ignore(e => e.Validator);
    }
}

public abstract class AggregateRootConfiguration<T, TKey> : DomainEntityWithValidatorConfiguration<T, TKey>
    where T : AggregateRoot<T, TKey>
{
    public override void Configure(EntityTypeBuilder<T> entity)
    {
        base.Configure(entity);

        entity.Ignore(c => c.DomainEvents);
    }
}