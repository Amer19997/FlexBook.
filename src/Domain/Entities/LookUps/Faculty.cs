using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Entities.LookUps;
public class Faculty:BaseEntity<Guid>
{
    public string NameAr {  get; set; }
    public string NameEn {  get; set; }
    public LookUpStatus LookUpStatus { get; set; }
    public Guid UniversityId {  get; set; }
    public University University {  get; set; }
    public List<Department> DepartmentList { get; set; }
    public List<User> UserList { get; set; }
}
