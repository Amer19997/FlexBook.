using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Entities.LookUps;
public class University: BaseEntity<Guid>
{
    public string NameAr { get; set; }
    public string NameEn {  get; set; }
    public LookUpStatus LookUpStatus {  get; set; }
    public int CountryId {  get; set; }
    public Country Country { get; set; }
    public List<Faculty> FacultyList {  get; set; }
    public List<User> UserList { get; set; }

}
