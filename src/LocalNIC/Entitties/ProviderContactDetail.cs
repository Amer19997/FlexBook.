namespace Waqfi.LocalNIC.Entities;

public class ProviderContactDetails 
{
    public string? PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? PhoneNumberCountryCode { get; set; }
    public string? MobileNumberCountryCode { get; set; }
    public Guid? Id { get; set; }
    public Guid? SocietyId { get; set; }
    public Society? Society { get; set; }
}

