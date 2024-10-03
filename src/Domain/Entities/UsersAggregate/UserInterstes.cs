using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Entities.UsersAggregate;
public class UserInterstes:BaseEntity<int>
{
    public Guid UserId { get; set; }
    public User User {  get; set; }
    public int CourseId { get; set; }
    public Course Course {  get; set; }
}
