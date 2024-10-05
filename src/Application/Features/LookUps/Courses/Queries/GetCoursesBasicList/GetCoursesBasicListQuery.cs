using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesList;
using MediatR;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesBasicListQuery;
public record GetCoursesBasicListQuery : IRequest<TResponse<GetCoursesBasicListResult>>;
