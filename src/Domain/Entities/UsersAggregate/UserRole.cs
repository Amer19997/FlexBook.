namespace FlexBook.Domain.Entities.UsersAggregate;
public class UserRole
{
    public Guid RoleId { get; private set; }
    public Guid UserId { get; private set; }

    public  User User { get; private set; }
    public  Role Role { get; private set; }

    private UserRole()
    {
     
    }

    internal UserRole(Guid roleId, Guid userId)
    {
        RoleId = roleId;
        UserId = userId;
    }

    public static UserRole Init(Guid roleId, Guid userId)
     => new UserRole(roleId, userId);
}
