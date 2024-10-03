namespace FlexBook.Application.Common.Helpers;
public class Smtp
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FromEmail { get; set; }

    public string DisplayName { get; set; }
}
