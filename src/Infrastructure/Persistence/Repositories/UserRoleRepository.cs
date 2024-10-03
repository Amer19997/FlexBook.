using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlexBook.Application.UserRole.Queries.CreateNewUserRole;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    private readonly FlexBookDbContext _context;
    public UserRoleRepository(FlexBookDbContext context) : base(context)
    {
        _context = context;
    }

    public List<UserRole> GetUserRole(Guid UserId)
    {
        var GetUserRole = _context.UserRoles.Include(a=>a.Role).Where(a=>a.UserId==UserId).ToList();
        return GetUserRole;
    }


}
