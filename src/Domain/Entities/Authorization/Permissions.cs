using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Authorization;
public class Permission
{
    public Guid Id { get; set; }

    public string Action { get; set; }

    public string Resource { get; set; }  // E.g., "Books", "Users", etc.

    // Name property that concatenates Resource and Action
    public string Name { get; private set; }

    // Navigation property for many-to-many relationship with Role
    public List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    // Constructor that initializes the Name based on Resource and Action
    public Permission(string action, string resource)
    {
        Id = Guid.NewGuid();
        Action = action;
        Resource = resource;
        Name = $"{action.ToLower()}{resource.ToLower()}";  // Concatenating resource and action
    }
}