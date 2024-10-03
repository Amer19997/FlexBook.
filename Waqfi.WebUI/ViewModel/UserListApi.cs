namespace WebUI.ViewModel;

public class UserListApi
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string RegisterAt { get; set; }
    public int Status { get; set; }
    public string Roles { get; set; }
    public int? PageNumber { get; set; }
    public int? TotalcCount { get; set; }
    public int? TotalcCountFilter { get; set; }
    public string RolesString { get; set; }
    public DateTimeOffset Created { get; set; }



}
