using Microsoft.EntityFrameworkCore;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class RoleRepository : Repository<Role>, IRoleRepository
{
    private readonly FlexBookDbContext _context;
    public RoleRepository(FlexBookDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetRols()
    => await _context.Roles.Where(a=>a.IsActive).ToListAsync();
}
