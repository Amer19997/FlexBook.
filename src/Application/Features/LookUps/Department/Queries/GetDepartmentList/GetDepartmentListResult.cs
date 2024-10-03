namespace FlexBook.Application.Features.LookUps.Department.Queries.GetDepartmentList;
public class GetDepartmentListResult
{
   public List<DepartmentItem> DepartmentList {  get; set; }
}
public class DepartmentItem
{
    public Guid Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public Guid FacultyId { get; set; }
    public String FacultyName { get; set; }
    public bool IsActive { get; set; }
}
