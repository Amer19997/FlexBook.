// File: Middlewares/GlobalExceptionMiddleware.cs
using FlexBook.Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace FlexBook.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "An unexpected error occurred.";
            var errors = new List<string>();

            // Use the fully qualified name for FluentValidation.ValidationException
            switch (exception)
            {
                case FluentValidation.ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "Validation failed.";
                    errors = validationException.Errors.Select(e => e.ErrorMessage).ToList();
                    break;

                // Other exception cases
                case FlexBook.Application.Common.Exceptions.ValidationException appValidationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = appValidationException.Message;
                    errors.Add(appValidationException.Message); // or format as needed
                    break;

                case UnauthorizedAccessException _:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = "Unauthorized access.";
                    break;

                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "An unexpected error occurred.";
                    break;
            }

            var response = new
            {
                statusCode = (int)statusCode,
                message = message,
                errors = errors.Any() ? errors : null
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var jsonResponse = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
