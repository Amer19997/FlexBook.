using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Entities.Catalog;
public class Lesson : BaseEntity<Guid>
{
    public string NameAr { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public string ContentType { get; set; } = default!; // Video or PDF
    public string FileUrl { get; set; } = default!;
    public Guid SectionId { get; set; }
    public Section Section { get; set; } = default!;
}
