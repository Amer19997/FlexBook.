using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Entities.Catalog;
public class Section : BaseEntity<Guid>
{
    public string TitleAr { get; set; } = default!;
    public string TitleEn { get; set; } = default!;
    public Guid CourseId { get; set; }
    public Course Course { get; set; } = default!;
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}

