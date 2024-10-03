namespace WebUI.ViewModel;

public class UserAdminDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string RegisterAt { get; set; }
    public int Status { get; set; }
    public string Roles { get; set; }
}
