namespace FlexBook.Application.Features.LookUps.Country.Queries.GetCountryList;
public class GetCountryListResult
{
   public List<CountryItem> CountryList {  get; set; }
}
public class CountryItem
{
    public int Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public bool IsActive { get; set; }
}
