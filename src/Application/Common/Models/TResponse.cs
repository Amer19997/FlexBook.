namespace FlexBook.Application.Common.Models;
public class TResponse<T> : BaseResponse
{
    public T Result { get; set; }
    public static TResponse<T> Success(T t) => new TResponse<T>() { Result = t, Errors = Array.Empty<string>() };
    public static TResponse<T> Failure(params string[] errors) => new TResponse<T>() { Result = default, Errors = errors };
}

public class TResponse : BaseResponse
{
    public static TResponse Success() => new TResponse() { Errors = Array.Empty<string>()};
    public static TResponse Failure(params string[] errors) => new TResponse() { Errors = errors };
}