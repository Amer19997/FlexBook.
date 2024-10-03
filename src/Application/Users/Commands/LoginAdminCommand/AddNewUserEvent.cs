using MediatR;

namespace FlexBook.Application.Users.Commands.LoginAdminCommand;
public class AddNewUserEvent : INotification
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string ApiUrl { get; set; }

    public AddNewUserEvent(string email, string name, string url)
    {
        Email = email;
        Name = name;
        ApiUrl = url;
    }

}
