using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Entities.UsersAggregate;
public class RolePermission
{
    public int Id {  get; set; }
    public int permissionId {  get; set; }
    public Permission Permission {  get; set; }
    public Guid RoleId { get; set; }
    public Role Role {  get; set; }
}
