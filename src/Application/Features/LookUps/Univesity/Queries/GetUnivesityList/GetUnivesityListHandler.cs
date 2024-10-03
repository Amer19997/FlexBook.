using System.Linq.Expressions;
using MediatR;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.LookUps.Univesity.Queries.GetUnivesityList;
using FlexBook.Domain;
using FlexBook.Domain.Entities.LookUps;
using X.PagedList;

namespace FlexBook.Application.Features.LookUps.Univesity.Queries.GetCountryList;
public class GetUnivesityListHandler : IRequestHandler<GetUnivesityListQuery, TResponse<GetUnivesityListResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetUnivesityListHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<TResponse<GetUnivesityListResult>> Handle(GetUnivesityListQuery request, CancellationToken cancellationToken)
    {
        var resu = await _unitOfWork.UnivesityRepository.FindPagedList(filters: filter(),
                                                               includeProperties: "Country");

          var univesityList = resu.Select(m => new UnivesityItem
        {
            Id = m.Id,
            NameAr = m.NameAr,
            NameEn = m.NameEn,
            CountryId=m.CountryId,
            CountryName=m.Country.NameAr,
            IsActive = m.IsActive
        }).ToList();

        return TResponse<GetUnivesityListResult>.Success(new GetUnivesityListResult
        {
            UnivesityList = univesityList,
            
        });




    }

    private IEnumerable<Expression<Func<Domain.Entities.LookUps.University, bool>>> filter()
    {
        var filters = new List<Expression<Func<Domain.Entities.LookUps.University, bool>>>
    {
        x => x.LookUpStatus== Domain.Enums.LookUpStatus.Active
    };

        return filters;
    }

}
