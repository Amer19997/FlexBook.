using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Models;
using MediatR;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesList;
public record GetCoursesListQuery(int pageNumber, int pageSize) : IRequest<TResponse<GetCoursesListResult>>;
