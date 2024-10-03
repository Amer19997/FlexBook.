namespace Waqfi.LocalNIC.Entities;

public class Delegate 
{
     Delegate() { }

    internal Delegate(string name, string identityNumber, PhoneNumber mobileNumber, string email) : base()
    {
        Name = name;
        IdentityNumber = identityNumber;
        MobileNumber = mobileNumber;
        Email = email;
    }
    public Guid SocietyId { get; set; }
    public Society? Society { get; set; }
    public string? Name { get;  set; }
    public string? IdentityNumber { get;  set; }
    public PhoneNumber MobileNumber { get;  set; }
    public string? Email { get; set; }
    public Guid Id { get;  set; }
    
    internal void UpdateDelegate(Delegate providerDelegate)
    {
        Name = providerDelegate.Name;
        IdentityNumber = providerDelegate.IdentityNumber;
        MobileNumber = providerDelegate.MobileNumber;
        Email = providerDelegate.Email;
    }
}
