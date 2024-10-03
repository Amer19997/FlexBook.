using Microsoft.AspNetCore.Mvc;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.Admin.SignUpRequest.Commands.ChangeStatusOfRequest;
using FlexBook.Application.Features.Admin.SignUpRequest.Queries.GetSignUpRequestList;
using FlexBook.WebAPI.Controllers;

namespace WebAPI.Controllers.Admin;
[Route("api/v1/Admin/[controller]")]
[ApiController]
public class AdminAuthController : ApiControllerBase
{
    [HttpGet("GetSignUpRequestList")]
    public async Task<ActionResult<TResponse<GetSignUpListResult>>> GetSignUpRequestList([FromQuery]int pageNumber=1,int pageSize=10)
       => Ok(await Mediator.Send(new GetSignUpListQuery(pageNumber,pageSize)));

    [HttpPost("ChangeSignUpRequest")]
    public async Task<ActionResult<TResponse<GetSignUpListResult>>> ChangeSignUpRequest([FromBody] ChangeStatusOfRequestCommand command)
       => Ok(await Mediator.Send(command));

}
