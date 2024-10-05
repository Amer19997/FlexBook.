using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
   public class CourseDto
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; } = default!;
        public string NameEn { get; set; } = default!;
        public string DiscriptionAr { get; set; } = default!;
        public string DiscriptionEn { get; set; } = default!;
        public string CoverPhoto { get; set; } = default!;
        //public List<SectionDto> Sections { get; set; } = new List<SectionDto>();
    }