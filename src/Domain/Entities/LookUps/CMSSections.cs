namespace FlexBook.Domain.Entities.LookUps;
public class CMSSections: BaseEntity<int>
{
    public string NameAr {  get; set; }
    public string NameEn {  get; set; }
    public List<Permission> PermissionList {  get; set; }
}
