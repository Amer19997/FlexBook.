using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Entities.Catalog;
public class Topic : BaseEntity<Guid>
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}