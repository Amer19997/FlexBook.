using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FlexBook.Application.Common.Models;
using FlexBook.Domain;
using FlexBook.Domain.Entities.Catalog.Dtos;
using MediatR;

namespace FlexBook.Application.Features.LookUps.Topics.Queries.GetTopicsList;
public class GetTopicsWithCoursesQueryHandler : IRequestHandler<GetTopicsWithCoursesQuery, TResponse<GetTopicsResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper; 

    public GetTopicsWithCoursesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
 
    public async Task<TResponse<GetTopicsResult>> Handle(GetTopicsWithCoursesQuery request, CancellationToken cancellationToken)
    {
        // Assuming no filtering is required, but you can adjust based on the request properties
        var topics = await _unitOfWork.TopicRepository.FindAsync(
            filter: null,  // You can replace `null` with an actual filter if needed
            includeProperties: "Categories,Categories.Courses"  // Correctly handle multiple includes
        );

        // Map the result to DTOs
        var topicsresult= _mapper.Map<List<TopicDto>>(topics);
        return TResponse<GetTopicsResult>.Success(new GetTopicsResult
        {
            TopicsList = topicsresult
        });
    }

}




