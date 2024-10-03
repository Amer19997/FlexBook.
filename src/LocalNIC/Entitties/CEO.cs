namespace Waqfi.LocalNIC.Entities;

public class CEO 
{
     CEO() { }
    public Guid Id { get; set; }

    internal CEO(string name, string identityNumber, PhoneNumber mobileNumber, string email) : base()
    {

        Name = name;

        IdentityNumber = identityNumber;
        MobileNumber = mobileNumber;
        Email = email;
    }
    public Guid SocietyId { get; set; }
    public Society Society { get; set; }

    public string? Name { get;  set; }
    public string? IdentityNumber { get;  set; }
    public PhoneNumber? MobileNumber { get;  set; }
    public string? Email { get; set; }

    internal void UpdateCEO(CEO ceo)
    {
        Name = ceo.Name;
        IdentityNumber = ceo.IdentityNumber;
        MobileNumber = ceo.MobileNumber;
        Email = ceo.Email;
    }
}
