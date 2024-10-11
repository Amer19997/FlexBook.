using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class LessonDto
{
    public Guid Id { get; set; }
    public string NameAr { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    //public string ContentType { get; set; } = default!;
    //public string FileUrl { get; set; } = default!;
}