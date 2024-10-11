using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Models;
using FlexBook.Domain.Entities.Catalog.Dtos;
using MediatR;

namespace FlexBook.Application.Users.Commands.PortalSignInCommand;
public class PortalSignInCommand : IRequest<TResponse<AuthResponseDto>>
{
    public string Email { get; set; }
    public string Password { get; set; }

}
