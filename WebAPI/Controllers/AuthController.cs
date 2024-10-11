﻿using System.ComponentModel.DataAnnotations;
using FlexBook.Application.Common.Exceptions;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Common.Models.Dtos;
using FlexBook.Application.Features.Admin.Commnds.DashBoardLoginCommand;
using FlexBook.Application.Users.Commands.ForgetPasswordAdminCommand;
using FlexBook.Application.Users.Commands.LoginAdminCommand;
using FlexBook.Application.Users.Commands.PortalSignInCommand;
using FlexBook.Application.Users.Commands.SetPasswordCommand;
using FlexBook.Application.Users.Commands.SignUpCommand;
using FlexBook.Application.Users.Queries.CheckResetOTP;
using FlexBook.Domain.Entities.Catalog.Dtos;
using FlexBook.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ApiControllerBase
{
    //[HttpPost("Login")]
    //public async Task<ActionResult<TResponse<LoginResponeDto>>> Login([FromBody] LoginAdminCommand command)
    //   => Ok(await Mediator.Send(command));



    [HttpPost("Portallogin")]
    public async Task<ActionResult<TResponse<AuthResponseDto>>> PortalLogin(PortalSignInCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.success)
        {
            // Return the error response with its status code
            return StatusCode(result.StatusCode, result);
        }

        return Ok(result);
    }

    [HttpPost("ForgetPassword")]
    public async Task<ActionResult<TResponse<LoginResponeDto>>> ForgetPassword([FromBody] ForgetPasswordAdminCommand command)
       => Ok(await Mediator.Send(command));

    [HttpGet("CheckForgetPasswordOTP")]
    public async Task<ActionResult<TResponse<string>>> CheckForgetPasswordOTP(string email, string otp)
      => Ok(await Mediator.Send(new CheckResetOTPQuery(email, otp)));

    [HttpPost("VerifyForgetPassword")]
    public async Task<ActionResult<TResponse<LoginResponeDto>>> VerifyForgetPassword([FromBody] SetPaswordCommand command)
      => Ok(await Mediator.Send(command));

    [HttpPost("SignUp")]
    public async Task<ActionResult<TResponse<RegisterNewUserResult>>> SignUp([FromBody]RegisterNewUserCommand command)
      => Ok(await Mediator.Send(command));

    [HttpPost("Test")]
    public async Task<ActionResult> TestError()
    {
        throw new FlexBook.Application.Common.Exceptions.ValidationException(new List<FluentValidation.Results.ValidationFailure>
    {
        new FluentValidation.Results.ValidationFailure("Field", "Validation failed")
    });
    }

}
// Instead of just ValidationException, use the full namespace path
