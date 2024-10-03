namespace Waqfi.LocalNIC.Entities;

public class BoardMember
{
     BoardMember() { }

    internal BoardMember( string name, string identityNumber) : base()
    {
        Name = name;
        IdentityNumber = identityNumber;
    }

    public string? Name { get;  set; }
    public string? IdentityNumber { get;  set; }
    public string? Email { get; set; }
    public PhoneNumber? MobileNumber { get; set; }

    public Guid Id { get;  set; }
    public Guid? SocietyId { get; set; }
    public Society Society { get; set; }

}
