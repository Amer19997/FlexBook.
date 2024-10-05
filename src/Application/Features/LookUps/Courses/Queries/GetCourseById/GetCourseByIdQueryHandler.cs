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

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCourseById;



public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, TResponse<CourseDetailDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCourseByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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

        if (course == null)
        {
            return null;  // Return null if the course is not found
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