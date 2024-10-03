using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Waqfi.WebUI.Filters;
public class UIExceptionFilterAttribute : IActionFilter, IOrderedFilter//: ExceptionFilterAttribute
{
    public int Order => int.MaxValue;
    public void OnActionExecuted(ActionExecutedContext context) {

        if (context.Exception is UnauthorizedAccessException httpResponseException)
        {
            //context.Result = "test";

            context.ExceptionHandled = true;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
     
    }
}
