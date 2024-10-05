using FlexBook.Domain.Entities.Catalog;
using FlexBook.Domain.Entities.UsersAggregate;
using static System.Collections.Specialized.BitVector32;

namespace FlexBook.Domain.Entities.LookUps;
public class Course:BaseEntity<Guid>
{
    public string NameAr {  get; set; }
    public string NameEn {  get; set; }
    public string DiscriptionAr {  get; set; }
    public string DiscriptionEn {  get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public string CoverPhoto { get; set; } // Added CoverPhoto property
    public ICollection<FlexBook.Domain.Entities.Catalog.Section> Sections { get; set; } = new List<FlexBook.Domain.Entities.Catalog.Section>();
    // Add the following lines for the Topic relationship
    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }
    public List<UserInterstes> UserInterstesList { get; set; }
}
