using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.LookUps.Courses.Queries.GetCourseById;
using FlexBook.Application.Features.LookUps.Courses.Queries.GetCourses;
using FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesBasicListQuery;
using FlexBook.Application.Features.LookUps.Topics.Queries.GetTopicsList;
using FlexBook.Domain.Entities.Catalog.Dtos;
using FlexBook.WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers.Catalog;
[Route("api/[controller]")]
[ApiController]
public class CatalogController : ApiControllerBase
{
    //[HttpGet("UserInterests")]
    //public async Task<ActionResult<TResponse<GetCoursesBasicListResult>>> GetBasicCourseList()
    //{
    //    return Ok(await Mediator.Send(new GetCoursesBasicListQuery()));
    //}
    [HttpGet("GetTopics")]
    public async Task<ActionResult<TResponse<GetTopicsResult>>> GetTopicsWithCourses()
    {
        var result = await Mediator.Send(new GetTopicsWithCoursesQuery());
        return Ok(result);
    }
    // Get courses with optional filters for Topic, Category, and Keyword (with pagination, sorting, and includes)
    [HttpGet("GetCourses")]
  /*  [Authorize(Policy = "createbooks")] */ // Protect this endpoint with the "ViewCourses" policy

    public async Task<IActionResult> GetCourses(
        [FromQuery] Guid? topicId,
        [FromQuery] Guid? categoryId,
        [FromQuery] string keyword = "",
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortBy = "NameEn",
        [FromQuery] string sortDirection = "asc"
        /*[FromQuery] string includeProperties = ""*/)
    {
        var query = new GetCoursesQuery(topicId, categoryId, keyword, pageNumber, pageSize, sortBy, sortDirection);
        var result = await Mediator.Send(query);
        return Ok(result);
       
    }

    //// Endpoint to get a course by its ID
    //[HttpGet("courses/{courseId}")]
    //public async Task<IActionResult> GetCourseById(Guid courseId)
    //{
    //    var query = new GetCourseByIdQuery(courseId);
    //    var result = await Mediator.Send(query);
    //    if (result == null)
    //    {
    //        return NotFound();  // Return 404 if course is not found
    //    }
    //    return Ok(result);
    //}
    [HttpGet("{courseId}")]
    [ProducesResponseType(typeof(TResponse<CourseDetailDTO>), StatusCodes.Status200OK)]  // Success response
    [ProducesResponseType(typeof(TResponse<CourseDetailDTO>), StatusCodes.Status404NotFound)]  // Not found response
    public async Task<IActionResult> GetCourseById(Guid courseId)
    {
        var query = new GetCourseByIdQuery(courseId);

        // Send the query using Mediator
        var result = await Mediator.Send(query);

        // Check the result using the 'Success' property (without parentheses)
        if (!result.success)
        {
            // Return the error response with its status code
            return StatusCode(result.StatusCode, result);
        }

        // Return success response
        return Ok(result);
    }



}
