namespace FlexBook.Application.Common.Models;
public abstract class BaseResponse
{
    public bool success => !Errors.Any();

    public string[] Errors { get; set; }
}
