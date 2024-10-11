using Microsoft.AspNetCore.Mvc;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.Admin.SignUpRequest.Commands.ChangeStatusOfRequest;
using FlexBook.Application.Features.Admin.SignUpRequest.Queries.GetSignUpRequestList;
using FlexBook.WebAPI.Controllers;
using FlexBook.Application.Features.Admin.Commnds.DashBoardLoginCommand;
using FlexBook.Application.Features.LookUps.Courses.Queries.GetCourseById;
using FlexBook.Domain.Entities.Catalog.Dtos;

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



    [HttpPost("login")]
    public async Task<ActionResult<TResponse<AuthResponseDto>>> DashboardLogin(DashboardSignInCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.success)
        {
            // Return the error response with its status code
            return StatusCode(result.StatusCode, result);
        }

        return Ok(result);
    }
   
}
