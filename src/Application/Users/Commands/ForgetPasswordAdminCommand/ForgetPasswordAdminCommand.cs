using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Users.Commands.ForgetPasswordAdminCommand;
public class ForgetPasswordAdminCommand:IRequest<TResponse<ForgetPasswordAdminCommandResult>>
{
    public string Email { get; set; }
}
