using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class UserProfileDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserType { get; set; }  // Instructor, Student (from UserTypeEnum)
    public List<CourseDto> Courses { get; set; } = new List<CourseDto>();  // Only for instructors

}
