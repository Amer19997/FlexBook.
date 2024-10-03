using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Entities.LookUps;
public class Country: BaseEntity<int>
{
    public string NameAr { get; set; }
    public string NameEn {  get; set; }
    public List<University> UniversityList {  get; set; }
    public List<User> UserList { get; set; }

}
