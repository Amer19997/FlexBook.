using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Application.Common.Interfaces;
public interface ITokenService
{
    public string GetToken(Guid userId,Guid profieId, string providersIds);
    public string GetAdminToken(User admin);
    string GeneratePortalToken(User user, bool isInstructor = false);
    string GenerateDashboardToken(User user, string roleName = null);

}
