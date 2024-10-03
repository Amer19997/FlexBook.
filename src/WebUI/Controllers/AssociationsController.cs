using Microsoft.AspNetCore.Mvc;
using Waqfi.Application.Associations.Commands;
using Waqfi.WebUI.Controllers;

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AssociationsController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateAssociationCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}
