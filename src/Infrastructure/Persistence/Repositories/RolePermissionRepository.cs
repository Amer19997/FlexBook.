using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class RolePermissionRepository:Repository<RolePermission>, IRolePermissionRepository
{
    public RolePermissionRepository(FlexBookDbContext dbContext, IOptions<AppSettings> appSettings) : base(dbContext)
    {

    }

}
