using System;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.Authorization;
using FlexBook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlexBook.Infrastructure.Persistence.Repositories; // File-scoped namespace

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    private readonly FlexBookDbContext _context;

    public PermissionRepository(FlexBookDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    // Retrieve a permission by its name and resource
    public async Task<Permission?> GetByNameAndResourceAsync(string permissionName, string resourceName)
    {
        return await _context.Permissions
            .FirstOrDefaultAsync(p => p.Name == permissionName && p.Resource == resourceName);
    }

    // Retrieve a permission by its action and resource
    public async Task<Permission?> GetByActionAndResourceAsync(string action, string resource)
    {
        return await _context.Permissions
            .FirstOrDefaultAsync(p => p.Action == action && p.Resource == resource);
    }

    // Add a new permission to the database
    public async Task AddAsync(Permission permission)
    {
        // Ensure the permission object is not null to prevent exceptions
        if (permission == null) throw new ArgumentNullException(nameof(permission));

        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync();
    }
}
