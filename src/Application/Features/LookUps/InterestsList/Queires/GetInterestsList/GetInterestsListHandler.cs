using MediatR;
using FlexBook.Application.Common.Models;
using FlexBook.Domain;

namespace FlexBook.Application.Features.LookUps.InterestsList.Queires.GetInterestsList;
public record GetInterestsListQuery(int pageNumber, int pageSize) : IRequest<TResponse<GetInterstsListResult>>;

public class GetInterestsListHandler : IRequestHandler<GetInterestsListQuery, TResponse<GetInterstsListResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetInterestsListHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<TResponse<GetInterstsListResult>> Handle(GetInterestsListQuery request, CancellationToken cancellationToken)
    {
        var resu = await _unitOfWork.InterestsListRepository.FindPagedList(filters: null,
                                                               orderBy: q => q.OrderByDescending(r => r.Id),
                                                               pageNumber: request.pageNumber,
                                                               pageSize: request.pageSize);

        var total = await _unitOfWork.InterestsListRepository.CountAsync(filters: null);

        var interstsList = resu.Select(m => new InterstsItem
        {
            Id = m.Id,
            NameAr = m.NameAr,
            NameEn = m.NameEn

        }).ToList();

        return TResponse<GetInterstsListResult>.Success(new GetInterstsListResult
        {
            InterstsList = interstsList,
            pageNumber = request.pageNumber,
            pageSize = request.pageSize,
            TotalCount = total

        });
    }
}

public class GetInterstsListResult
{
    public List<InterstsItem> InterstsList { get; set; }
    public int TotalCount { get; set; }
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
}
public class InterstsItem
{
    public int Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
}