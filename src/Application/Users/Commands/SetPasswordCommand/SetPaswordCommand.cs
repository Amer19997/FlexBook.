using MediatR;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Users.Commands.SetPasswordCommand;
public class SetPaswordCommand : IRequest<TResponse<string>>
{
    public string Pasword { get; set; }
    public string VerifyPassword { get; set; }
    public string Email { get; set; }
    public string OTP { get; set; }

}
