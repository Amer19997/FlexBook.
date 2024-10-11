using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlexBook.Application.Features.Admin.Commnds.CreateRoleCommand;
using FlexBook.Domain.Entities;
using FlexBook.Domain.Entities.Catalog;
using FlexBook.Domain.Entities.Catalog.Dtos;
using FlexBook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlexBook.Infrastructure.Persistence.Repositories
{
  

  

 
    public class MyRoleRepository : Repository<Role>, RoleRepositoryInterface
    {
        private readonly FlexBookDbContext _context;

        public MyRoleRepository(FlexBookDbContext dbContext) : base(dbContext) 
        {
            _context = dbContext;
        }

        public async Task<GetRolDto?> GetByIdAsync(Guid? roleId)
        {
            var role = await _context.Roles
                .Where(r => r.Id == roleId)
                .Select(r => new GetRolDto
                {
                    RoleId = r.Id,
                    RoleName = r.Name,
                    Users = r.Users.Select(u => new GetUserDto
                    {
                        UserId = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email
                    }).ToList(),
                    Permissions = r.RolePermissions.Select(rp => new GetPermissionDto
                    {
                        PermissionId = rp.Permission.Id,
                        Action = rp.Permission.Action,
                        Resource = rp.Permission.Resource,
                        PermissionName = rp.Permission.Name
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (role == null)
            {
                throw new KeyNotFoundException($"Role with Id {roleId} was not found.");
            }

            return role;
        }


        public async Task AddAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
