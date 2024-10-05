using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class CourseDetailDTO
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string DiscriptionAr { get; set; }
    public string DiscriptionEn { get; set; }
   
   public List<SectionDto> Sections { get; set; } = new List<SectionDto>();

}
