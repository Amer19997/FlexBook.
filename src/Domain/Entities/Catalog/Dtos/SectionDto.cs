using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class SectionDto
{
    public Guid Id { get; set; }
    public string TitleAr { get; set; }
    public string TitleEn { get; set; }
    public List<LessonDto> Lessons { get; set; } = new();
}
