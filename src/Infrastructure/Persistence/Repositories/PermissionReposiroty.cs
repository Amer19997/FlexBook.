using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class PermissionReposiroty:Repository<Permission>, IPermissionReposiroty
{

    public PermissionReposiroty(FlexBookDbContext dbContext) : base(dbContext)
    {

    }
}
