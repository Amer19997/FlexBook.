
using Microsoft.AspNetCore.Http;

namespace FlexBook.Domain.Common;
public class Files
{
    public IFormFile File { get; set; }
    public FileTypeEnum FileType { get; set; }
}
public enum FileTypeEnum
{
    Logo = 1,
    Other = 2
}
