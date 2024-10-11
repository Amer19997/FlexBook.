using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class GetPermissionDto
{
    public Guid PermissionId { get; set; }
    public string Action { get; set; }
    public string Resource { get; set; }
    public string PermissionName { get; set; }
}
