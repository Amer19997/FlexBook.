namespace FlexBook.Domain.Common;

public abstract class AuditableAggregateRoot<TAggregate, TKey> : AggregateRoot<TAggregate, TKey>
    where TAggregate : DomainEntity<TKey>
{
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
