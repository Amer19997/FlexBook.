using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.Authorization;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Entities;


public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    // Navigation property to RolePermissions (many-to-many relationship)
    public List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    // Navigation property to Users
    public List<User> Users { get; set; } = new List<User>();
}