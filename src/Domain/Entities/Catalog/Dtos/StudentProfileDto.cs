using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class StudentProfileDto : UserProfileDto
{
    public string AcademicYear { get; set; }  // Specific to students
    public string StudyLevel { get; set; }    // Specific to students
    public List<CourseDto> EnrolledCourses { get; set; } = new List<CourseDto>();  // Only for students
}
