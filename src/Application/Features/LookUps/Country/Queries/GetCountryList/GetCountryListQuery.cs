using MediatR;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Features.LookUps.Country.Queries.GetCountryList;
public record GetCountryListQuery():IRequest<TResponse<GetCountryListResult>>;
