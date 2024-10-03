namespace FlexBook.Domain.Common;
public abstract class DomainException : Exception
{
    public DomainException(IEnumerable<string> erros)
        : base(string.Join(",", erros))
    {

    }
}
