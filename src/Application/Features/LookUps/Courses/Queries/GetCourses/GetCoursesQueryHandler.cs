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
using FlexBook.Application.Features.LookUps.Topics.Queries.GetTopicsList;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCourses;
public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, TResponse<GetCoursesResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCoursesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
 
    public async Task<TResponse<GetCoursesResult>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        // Call the repository method with sorting, pagination, and include properties
        var pagedCourses = await _unitOfWork.CouresRepository.GetPaginatedCoursesWithFilterAsync(
            request.TopicId,
            request.CategoryId,
            request.Keyword,
            request.PageNumber,
            request.PageSize,
            request.SortBy,
            request.SortDirection,
            //  request.IncludeProperties,  // Include Properties
            cancellationToken
        );
        var total = await _unitOfWork.CouresRepository.CountCoursesAsync(request.TopicId,
            request.CategoryId,
            request.Keyword,
          
            //  request.IncludeProperties,  // Include Properties
            cancellationToken);

        // Map the result to CourseDto (paged)
        var coursesresult = _mapper.Map<IPagedList<CourseDto>>(pagedCourses);
        return TResponse<GetCoursesResult>.Success(new GetCoursesResult
        {
            Courseslist = coursesresult.ToList(),
            TotalCount = total
            
        });
    }
    public async Task<TResponse<GetTopicsResult>> Handle(GetTopicsWithCoursesQuery request, CancellationToken cancellationToken)
    {
        // Assuming no filtering is required, but you can adjust based on the request properties
        var topics = await _unitOfWork.TopicRepository.FindAsync(
            filter: null,  // You can replace `null` with an actual filter if needed
            includeProperties: "Categories,Categories.Courses"  // Correctly handle multiple includes
        );

        // Map the result to DTOs
        var topicsresult = _mapper.Map<List<TopicDto>>(topics);
        return TResponse<GetTopicsResult>.Success(new GetTopicsResult
        {
            TopicsList = topicsresult
        });
    }
}