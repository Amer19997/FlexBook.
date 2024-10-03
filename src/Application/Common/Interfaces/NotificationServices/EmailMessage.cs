namespace FlexBook.Application.Common.Interfaces.NotificationServices;
public class EmailMessage : Message
{
    public string EmailAddress { get; private set; }
    public string Subject { get; private set; }
    public string Body { get; private set; }

    public EmailMessage(string emailAddress, string subject, string body)
    {
        EmailAddress = emailAddress;
        Subject = subject;
        Body = body;
    }
}
