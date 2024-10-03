using MediatR;
using Microsoft.Extensions.Logging;
using FlexBook.Application.Common.Interfaces;

namespace FlexBook.Application.Common.Behaviours;
public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId ?? string.Empty;

        //Request
        _logger.LogInformation("FlexBook Request: {Name} {@UserId} {@Request}",
            requestName, userId, request);

        var response = await next();

        //Response
        _logger.LogInformation("{Name} Response : {@Response}", requestName, response);

        return response;
    }
}
