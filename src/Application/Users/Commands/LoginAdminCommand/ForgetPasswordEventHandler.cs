using MediatR;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces.NotificationServices;

namespace FlexBook.Application.Users.Commands.LoginAdminCommand;

public class ForgetPasswordEventHandler : INotificationHandler<ForgetPasswordEvent>
{
    private readonly INotificationService _notificationService;

    public ForgetPasswordEventHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task Handle(ForgetPasswordEvent notification, CancellationToken cancellationToken)
    {
        var template = new ForgotPasswordTemplateBody() {  Name = notification.FullName ,ApiUrl =notification.ApiUrl,OTP= notification.OTP };
        var body = $"{template.Body}";
        _notificationService.Push(new EmailMessage(notification.Email,template.Subject, body));
    }
}
