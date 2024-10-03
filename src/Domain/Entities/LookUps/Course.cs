using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Entities.LookUps;
public class Course:BaseEntity<int>
{
    public string NameAr {  get; set; }
    public string NameEn {  get; set; }
    public string DiscriptionAr {  get; set; }
    public string DiscriptionEn {  get; set; }
    public string CoverPhoto { get; set; } // Added CoverPhoto property

    public List<UserInterstes> UserInterstesList { get; set; }
}
