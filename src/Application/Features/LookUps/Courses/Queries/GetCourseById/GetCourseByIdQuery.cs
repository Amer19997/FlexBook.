using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Models;
using FlexBook.Domain.Entities.Catalog.Dtos;
using MediatR;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCourseById;
 public record GetCourseByIdQuery(Guid CourseId) : IRequest<TResponse<CourseDetailDTO>>;
