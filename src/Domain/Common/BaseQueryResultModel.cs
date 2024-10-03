namespace FlexBook.Domain.Common;
public class BaseQueryResultModel<T>
{
    public List<T> Items { get; }
    public int TotalCount { get; }
    public int TotalCountFilter { get; }
    public BaseQueryResultModel(List<T> items, int count, int totalCountFilter)
    {
        TotalCount = count;
        Items = items;
        TotalCountFilter = totalCountFilter;
    }
}
