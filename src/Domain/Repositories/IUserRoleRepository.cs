using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Repositories;
public interface IUserRoleRepository : IRepository<UserRole>
{
   List<UserRole> GetUserRole(Guid UserId);

}
