using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Entities.LookUps;
public class Department: BaseEntity<Guid>
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public LookUpStatus LookUpStatus { get; set; }
    public Guid? FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public List<User> UserList { get; set; }
}
