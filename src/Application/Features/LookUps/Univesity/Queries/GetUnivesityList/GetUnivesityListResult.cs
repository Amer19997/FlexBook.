namespace FlexBook.Application.Features.LookUps.Univesity.Queries.GetUnivesityList;
public class GetUnivesityListResult
{
   public List<UnivesityItem> UnivesityList {  get; set; }
}
public class UnivesityItem
{
    public Guid Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public int CountryId { get; set; }
    public String CountryName { get; set; }
    public bool IsActive { get; set; }
}
