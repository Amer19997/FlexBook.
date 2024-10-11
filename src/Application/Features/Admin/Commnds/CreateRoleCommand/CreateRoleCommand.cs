using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FlexBook.Application.Features.Admin.Commnds.CreateRoleCommand;
// Command to create a new role
public class CreateRoleCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public List<PermissionDto> Permissions { get; set; }
}

// DTO for the permissions in the request
public class PermissionDto
{
    public string Action { get; set; }
    public string Resource { get; set; }
}
