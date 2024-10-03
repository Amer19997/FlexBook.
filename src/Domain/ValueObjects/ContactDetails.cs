
namespace FlexBook.Domain.ValueObjects;

public class ContactDetails : ValueObject
{
   //  (string LandlineCountryCode, string Landline, string MobileNumberCountryCode, string MobileNumber, string Email, string Website) _value;

    public string PhoneNumber { get;  set; }
    public string MobileNumber { get;  set; }
    public string Email { get;  set; }
    public string Website { get;  set; }
    public string PhoneNumberCountryCode { get;  set; }
    public string MobileNumberCountryCode { get;  set; }

     public ContactDetails() { }

    public ContactDetails(string landlineCountryCode, string landline, string mobileNumberCountryCode, string mobileNumber, string email, string website)
    {
        PhoneNumber = landline;
        MobileNumber = mobileNumber;
        Email = email;
        Website = website;
        PhoneNumberCountryCode = landlineCountryCode;
        MobileNumberCountryCode = mobileNumberCountryCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PhoneNumber;
        yield return MobileNumber;
        yield return Email;
        yield return Website;
    }
}
