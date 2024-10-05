using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class CategoryNameDto
{
    public Guid Id { get; set; }

    public string NameAr { get; set; }
    public string NameEn { get; set; }
}
