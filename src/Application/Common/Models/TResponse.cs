namespace FlexBook.Application.Common.Models
{
    public class TResponse<T> : BaseResponse
    {
        public T Result { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }  // Add message property

        public static TResponse<T> Success(T result, string message = null, int statusCode = 200) =>
            new TResponse<T>() { Result = result, StatusCode = statusCode, Message = message, Errors = Array.Empty<string>() };

        public static TResponse<T> Failure(string[] errors, string message = null, int statusCode = 400) =>
            new TResponse<T>() { Result = default, StatusCode = statusCode, Message = message, Errors = errors };
    }

    public class TResponse : BaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }  // Add message property

        public static TResponse Success(string message = null, int statusCode = 200) =>
            new TResponse() { StatusCode = statusCode, Message = message, Errors = Array.Empty<string>() };

        public static TResponse Failure(string[] errors, string message = null, int statusCode = 400) =>
            new TResponse() { StatusCode = statusCode, Message = message, Errors = errors };
    }
}
