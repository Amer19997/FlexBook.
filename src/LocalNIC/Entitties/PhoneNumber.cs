namespace Waqfi.LocalNIC.Entities;
public class PhoneNumber
{
    public string? CountryCode { get;  set; }
    public string? MobileNumber { get;  set; }

     PhoneNumber() { }

    public PhoneNumber(string countryCode, string Number)
    {
        CountryCode = countryCode;
        this.MobileNumber = Number;
    }


}
