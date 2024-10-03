using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Entities.LookUps;
public class Permission
{
    public int Id { get; set; }
    public int CMSSectionId {  get; set; }
    public CMSSections CMSSection {  get; set; }
    public CMSActionTypes Action {  get; set; }

    public List<RolePermission> RolePermissionList { get; set; }
}
