namespace FlexBook.Domain.Exceptions;

public class LookupDomainException : DomainException
{
    public LookupDomainException(IEnumerable<string> erros) : base(erros)
    {
    }
}
