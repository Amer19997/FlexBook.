using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FlexBook.Domain.Common;

namespace FlexBook.Application.Users.Commands.LoginAdminCommand;
public class ForgetPasswordEvent : INotification
{
    public string Email { get;private set; }
    public string FullName { get; private set; }
    public string ApiUrl { get; set; }
    public string OTP {  get; set; }

    public ForgetPasswordEvent(string email, string fullName, string apiUrl, string oTP)
    {
        Email = email;
        FullName = fullName;
        ApiUrl = apiUrl;
        OTP = oTP;
    }

}
