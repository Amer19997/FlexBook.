namespace FlexBook.Domain.Entities.UsersAggregate;
public class Role
{
    public Guid Id {  get; set; }
    public DescriptionLocalized Name { get;  set; }
    public bool IsActive {  get; set; }

    public List<RolePermission> RolePermissionList {  get; set; }
}
