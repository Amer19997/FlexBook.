namespace FlexBook.Application.Common.Models;
public abstract class BaseResponse
{
    public bool Success => !Errors.Any();

    public string[] Errors { get; set; }
}
