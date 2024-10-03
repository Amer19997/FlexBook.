namespace FlexBook.Application.Common.Interfaces.NotificationServices;
public interface INotificationService
{
    public void Push(params Message[] messages);
}
