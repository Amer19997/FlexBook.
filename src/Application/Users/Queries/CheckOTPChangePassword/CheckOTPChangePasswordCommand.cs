using MediatR;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Users.Queries.CheckOTPChangePassword;
public class CheckOTPChangePasswordCommand : IRequest<TResponse<string>>
{
    public string OTP { get; set; }
    public string Email {  get; set; }
}
