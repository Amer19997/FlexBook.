using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Models;
using FlexBook.Domain.Entities.Catalog.Dtos;
using MediatR;

namespace FlexBook.Application.Features.Admin.Commnds.DashBoardLoginCommand;
public class DashboardSignInCommand : IRequest<TResponse<AuthResponseDto>>
{
    public string EmailOrName { get; set; }
    public string Password { get; set; }
}

