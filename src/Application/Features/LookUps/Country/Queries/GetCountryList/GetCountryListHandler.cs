using MediatR;
using FlexBook.Application.Common.Models;
using FlexBook.Domain;
using FlexBook.Domain.Entities.LookUps;
using X.PagedList;

namespace FlexBook.Application.Features.LookUps.Country.Queries.GetCountryList;
public class GetCountryListHandler : IRequestHandler<GetCountryListQuery, TResponse<GetCountryListResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCountryListHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<TResponse<GetCountryListResult>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
    {
        var resu = await _unitOfWork.CountryRepository.FindPagedList(filters: null);

        var countryList = resu.Select(m => new CountryItem
        {
            Id = m.Id,
            NameAr = m.NameAr,
            NameEn = m.NameEn,
            IsActive = m.IsActive
        }).ToList();

        return TResponse<GetCountryListResult>.Success(new GetCountryListResult
        {
            CountryList = countryList
        });
    }
}
