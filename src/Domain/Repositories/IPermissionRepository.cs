using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.Authorization;

namespace FlexBook.Domain.Repositories;
public interface IPermissionRepository
{
    Task<Permission> GetByNameAndResourceAsync(string permissionName, string resourceName);
    Task<Permission> GetByActionAndResourceAsync(string action, string resource);
    Task AddAsync(Permission permission);
}
