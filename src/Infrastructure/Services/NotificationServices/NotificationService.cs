using FlexBook.Application.Common.Interfaces.NotificationServices;

namespace FlexBook.Infrastructure.Services.NotificationServices;
public class NotificationService : INotificationService
{
    private readonly IEmailProviderSender _emailSender;
    

    public NotificationService(IEmailProviderSender emailSender)
    {
        _emailSender = emailSender;
    }
    public void Push(params Message[] messages)
    {
        

        messages.Where(_ => _ is EmailMessage).ToList().ForEach(async __ =>
        {
            await _emailSender.SendAsync(__ as EmailMessage);
        });
    }
}



