using System.Xml.Linq;

namespace FlexBook.Application.Common.Models;
public class PaginationInput
{
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;

}
