using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Models;
using FlexBook.Domain.Entities.Catalog.Dtos;
using MediatR;
using X.PagedList;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCourses;
// Application/Queries/GetCoursesQuery.cs
public record GetCoursesQuery(
    Guid? TopicId,
    Guid? CategoryId,
    string Keyword = "",
    int PageNumber = 1,
    int PageSize = 10,
    string SortBy = "NameEn",
    string SortDirection = "asc"
   // string IncludeProperties = ""  // Added Include Properties
) : IRequest<TResponse<GetCoursesResult>>;
