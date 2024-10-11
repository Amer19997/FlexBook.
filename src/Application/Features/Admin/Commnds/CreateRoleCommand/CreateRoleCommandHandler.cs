using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.Authorization;
using FlexBook.Domain.Entities;
using FlexBook.Domain.Repositories;
using MediatR;

namespace FlexBook.Application.Features.Admin.Commnds.CreateRoleCommand;
public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly RoleRepositoryInterface _roleRepository;
    private readonly IPermissionRepository _permissionRepository;

    public CreateRoleCommandHandler(RoleRepositoryInterface roleRepository, IPermissionRepository permissionRepository)
    {
        _roleRepository = roleRepository;
        _permissionRepository = permissionRepository;
    }

    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        // Create a new Role
        var role = new Role { Id = Guid.NewGuid(), Name = request.Name };

        // Process permissions from the request
        foreach (var permDto in request.Permissions)
        {
            // Check if the permission already exists, or create a new one
            var existingPermission = await _permissionRepository.GetByActionAndResourceAsync(permDto.Action, permDto.Resource);

            Permission permission;
            if (existingPermission != null)
            {
                permission = existingPermission;
            }
            else
            {
                // Create a new permission if it doesn't exist
                permission = new Permission(permDto.Action, permDto.Resource);
                await _permissionRepository.AddAsync(permission);
            }

            // Create the relationship between the Role and Permission
            var rolePermission = new RolePermission
            {
                RoleId = role.Id,
                PermissionId = permission.Id
            };

            role.RolePermissions.Add(rolePermission);
        }

        // Save the role and permissions to the database
        await _roleRepository.AddAsync(role);

        // Return the new Role ID
        return role.Id;
    }
}
