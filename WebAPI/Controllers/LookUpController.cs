using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.LookUps.Country.Queries.GetCountryList;
using FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesList;
using FlexBook.Application.Features.LookUps.Department.Queries.GetDepartmentList;
using FlexBook.Application.Features.LookUps.Faculty.Queries.GetFacultyList;
using FlexBook.Application.Features.LookUps.Univesity.Queries.GetUnivesityList;
using FlexBook.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class LookUpController : ApiControllerBase
{
    [HttpGet("GetCountryList")]
    public async Task<ActionResult<TResponse<GetCountryListResult>>> GetCountryList()
        => Ok(await Mediator.Send(new GetCountryListQuery()));

    //====================================================================================================================================

    [HttpGet("GetUnivesityList")]
    public async Task<ActionResult<TResponse<GetUnivesityListResult>>> GetUnivesityList()
      => Ok(await Mediator.Send(new GetUnivesityListQuery()));

    //=====================================================================================================================================    //====================================================================================================================================
    [HttpGet("GetFacultyList")]
    public async Task<ActionResult<TResponse<GetFacultyListResult>>> GetFacultyList(Guid univesityId)
  => Ok(await Mediator.Send(new GetFacultyListQuery(univesityId)));
    //=====================================================================================================================================    //====================================================================================================================================
    
    [HttpGet("GetCouresList")]
    public async Task<ActionResult<TResponse<GetCoursesListResult>>> GetCouresList(int pageNumber = 1, int pageSize = 10)
  => Ok(await Mediator.Send(new GetCoursesListQuery(pageNumber, pageSize)));

    //=====================================================================================================================================    //====================================================================================================================================

    [HttpGet("GetDepartmentList")]
    public async Task<ActionResult<TResponse<GetDepartmentListResult>>> GetDepartmentList(Guid facultyId)
      => Ok(await Mediator.Send(new GetDepartmentListQuery(facultyId)));

    //========================================================================
    [HttpGet("GetBasicCourseList")]
    public async Task<ActionResult<TResponse<GetCoursesBasicListResult>>> GetBasicCourseList()
    {
        return Ok(await Mediator.Send(new GetCoursesBasicListQuery()));
    }


}
