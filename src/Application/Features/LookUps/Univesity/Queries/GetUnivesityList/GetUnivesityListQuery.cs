using MediatR;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Features.LookUps.Univesity.Queries.GetUnivesityList;
public record GetUnivesityListQuery():IRequest<TResponse<GetUnivesityListResult>>;
