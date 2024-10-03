using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Common.Models.Dtos;

namespace FlexBook.Application.Users.Commands.LoginAdminCommand;
public class LoginAdminCommand : IRequest<TResponse<LoginResponeDto>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
