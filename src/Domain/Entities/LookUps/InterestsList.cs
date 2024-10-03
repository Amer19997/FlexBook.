using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Entities.LookUps;
public class InterestsList:BaseEntity<int>
{
    public string NameAr {  get; set; }
    public string NameEn {  get; set; }
    public List<UserInterstes> UserInterstesList { get;  set; }

}
