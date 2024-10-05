using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class CategoryDto
{
    public Guid Id { get; set; }
    public string NameAr { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
}
