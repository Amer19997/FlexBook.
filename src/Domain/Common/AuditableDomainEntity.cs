namespace FlexBook.Domain.Common;

public interface IAuditableDomainEntity
{
    DateTime Created { get; set; }
    string CreatedBy { get; set; }
    DateTime? LastModified { get; set; }
    string LastModifiedBy { get; set; }
}

public abstract class AuditableDomainEntity<TEntity, TKey> : DomainEntity<TEntity, TKey>, IAuditableDomainEntity
    where TEntity : class
{
    public DateTime Created { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string LastModifiedBy { get; set; }
}
