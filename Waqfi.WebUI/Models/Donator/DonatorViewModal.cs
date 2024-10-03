namespace WebUI.Models.Donator;

public class DonatorViewModal
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string CountryCode { get; set; }
    public string MobileNumber { get; set; }

    public string? CreationDate { get; set; }

    public int CounterPage { get; set; }

}
