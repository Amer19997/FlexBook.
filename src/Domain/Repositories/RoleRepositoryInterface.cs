using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities;
using FlexBook.Domain.Entities.Catalog.Dtos;

namespace FlexBook.Domain.Repositories;
public interface RoleRepositoryInterface
{
    Task<GetRolDto> GetByIdAsync(Guid? roleId);
    Task AddAsync(Role role);
    Task UpdateAsync(Role role);
    Task<List<Role>> GetAllRolesAsync();
}
