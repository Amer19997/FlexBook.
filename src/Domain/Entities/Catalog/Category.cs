using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Entities.Catalog;
public class Category : BaseEntity<Guid>
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
