using FlexBook.Application.Features.Admin.Commnds.CreateRoleCommand;
using FlexBook.Domain;
using FlexBook.WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Admin;
[Route("api/[controller]")]
[ApiController]
public class RolesController : ApiControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public RolesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Roles/{roleId}
    [HttpGet("{roleId}")]
    public async Task<IActionResult> GetRoleById(Guid roleId)
    {

            // Fetch the role by ID
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(roleId);

            if (role == null)
            {
                // Return 404 if the role is not found
                return NotFound(new { message = "Role not found" });
            }

            // Return 200 OK with the role data
            return Ok(role);
        
      
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
    {
        var roleId = await Mediator.Send(command);
        return Ok(roleId);
    }
}