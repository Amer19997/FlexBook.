using MediatR;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Features.LookUps.Department.Queries.GetDepartmentList;
public record GetDepartmentListQuery(Guid facultyId) :IRequest<TResponse<GetDepartmentListResult>>;
