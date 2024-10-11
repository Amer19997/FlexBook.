using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.Authorization;
using FlexBook.Domain.Entities;
using FlexBook.Domain.Repositories;
using MediatR;

namespace FlexBook.Application.Features.Admin.Commnds.CreateRoleWithPermissionsCommand;
public class CreateRoleWithPermissionsCommand : IRequest<Guid>
{
    public string RoleName { get; set; }
    public List<EntityPermissionDto> EntityPermissions { get; set; }

    public class Handler : IRequestHandler<CreateRoleWithPermissionsCommand, Guid>
    {
        private readonly RoleRepositoryInterface _roleRepository;
        private readonly IPermissionRepository _permissionRepository;

        public Handler(RoleRepositoryInterface roleRepository, IPermissionRepository permissionRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<Guid> Handle(CreateRoleWithPermissionsCommand request, CancellationToken cancellationToken)
        {
            var role = new Role { Name = request.RoleName };
            await _roleRepository.AddAsync(role);

            foreach (var entityPermission in request.EntityPermissions)
            {
                foreach (var permission in entityPermission.Permissions)
                {
                    var permissionEntity = await _permissionRepository.GetByNameAndResourceAsync(permission, entityPermission.Entity);
                    if (permissionEntity != null)
                    {
                        role.RolePermissions.Add(new RolePermission { RoleId = role.Id, PermissionId = permissionEntity.Id });
                    }
                }
            }

            await _roleRepository.UpdateAsync(role);
            return role.Id;
        }
    }
}

public class EntityPermissionDto
{
    public string Entity { get; set; }   // e.g., "Books"
    public List<string> Permissions { get; set; }   // e.g., ["View", "Edit"]
}