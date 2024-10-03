namespace FlexBook.Domain.Common;

public interface IDomainEntity { }

public abstract class DomainEntity<TKey> : IDomainEntity
{
    public TKey Id { get; set; } = default!;
}

public abstract class DomainEntity<TEntity, TKey> : DomainEntity<TKey>
    where TEntity : class
{
    public DomainValidator<TEntity> Validator { get; } = new();
}
