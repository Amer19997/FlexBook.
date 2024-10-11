using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class GetRolDto
{
    public Guid RoleId { get; set; }
    public string RoleName { get; set; }
    public List<GetUserDto> Users { get; set; } = new List<GetUserDto>();
    public List<GetPermissionDto> Permissions { get; set; } = new List<GetPermissionDto>();
}