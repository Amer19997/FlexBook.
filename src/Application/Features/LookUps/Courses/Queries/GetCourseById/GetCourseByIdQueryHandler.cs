using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FlexBook.Domain.Entities.Catalog.Dtos;
using FlexBook.Domain;
using MediatR;
using X.PagedList;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.LookUps.Courses.Queries.GetCourses;
using FlexBook.Application.Users.Commands.SignUpCommand;
using FlexBook.Application.Common.Interfaces;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCourseById;



public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, TResponse<CourseDetailDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IResourceService _resourceService;

    public GetCourseByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IResourceService resourceService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _resourceService = resourceService;

    }

    public async Task<TResponse<CourseDetailDTO>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        // Explicitly set the related entities to include (Sections and Lessons)
        string includeProperties = "Sections,Sections.Lessons";

        // Call GetByIdAsync directly with the set includeProperties
        var course = await _unitOfWork.CouresRepository.GetByIdAsync(
            c => c.Id == request.CourseId,  // Filter by CourseId
            includeProperties,              // Include Sections and Lessons
            cancellationToken);

        // Handle case where no course is found
        if (course == null)
        {
            // Return a proper error response when course is not found
            return TResponse<CourseDetailDTO>.Failure(
                new [] { _resourceService.GetError("Course with the given ID was not found.") },
                _resourceService.GetError("Course with the given ID was not found."),
                404
            );
        }
 

        // Map the course entity to the CourseDto
        CourseDetailDTO coursedto = _mapper.Map<CourseDetailDTO>(course);
        return TResponse<CourseDetailDTO>.Success(coursedto);
    }


//    var coursesresult = _mapper.Map<IPagedList<CourseDto>>(pagedCourses);
//        return TResponse<GetCoursesResult>.Success(new GetCoursesResult
//        {
//            Courseslist = coursesresult.ToList(),
//            TotalCount = total

//});







}