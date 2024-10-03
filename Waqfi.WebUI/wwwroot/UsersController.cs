using Microsoft.AspNetCore.Mvc;
using Waqfi.Application.Common.Models;
using Waqfi.Application.Users.Queries.GetAllAdminUserQuery;
using Waqfi.WebAPI.Controllers;

namespace WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ApiControllerBase
{

    [HttpGet(nameof(GetAllAdminUsers))]
    public async Task<ActionResult<TResponse>> GetAllAdminUsers(GetAllAdminUserQuery query)
    => Ok(await Mediator.Send(query));



    //[HttpGet(nameof(GetAllAdminUsers))]
    //public async Task<ActionResult> GetAllAdminUsers(GetAllAdminUserQuery query)
    //{
    //  return Ok(await Mediator.Send(query));

    //}
}
