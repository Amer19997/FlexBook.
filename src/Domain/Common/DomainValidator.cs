using System.Linq.Expressions;
using System.Reflection;

namespace FlexBook.Domain.Common;
public class DomainValidator<T> where T : class
{
    private readonly List<string> errors = new();
    public DomainValidator<T> Required<Value>(Expression<Func<T, Value>> action, Value value)
    {
        PropertyInfo property = action.Body switch
        {
            MemberExpression mbr => (PropertyInfo)mbr.Member,
            UnaryExpression mbr => (PropertyInfo)((MemberExpression)mbr.Operand).Member,
            _ => throw new NotSupportedException("Expression type is not supported")
        };
        var defaultComparer = EqualityComparer<Value>.Default;
        string error = $"{property.Name} value is empty/null/default";

        if (value is null)
        {
            errors.Add(error);
            return this;
        }

        bool notValid = (defaultComparer, value) switch
        {
            (EqualityComparer<string>, _) => string.IsNullOrWhiteSpace(value?.ToString()),
            (_, Enum) => !Enum.IsDefined(property.PropertyType, value.ToString()!),
            _ => defaultComparer.Equals(value, default),
        };

        if (notValid)
            errors.Add(error);

        return this;
    }
    
    public void Validate<TDomainException>() where TDomainException : DomainException
    {
        if (errors.Any())
            throw (TDomainException)Activator.CreateInstance(typeof(TDomainException), errors)!;
    }

    public IReadOnlyList<string> TryValidate() => errors;
}
