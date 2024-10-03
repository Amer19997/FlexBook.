namespace Waqfi.LocalNIC.Entities;
public class BoardChairman 
{
     BoardChairman() { }

    internal BoardChairman(Guid id, string name, string identityNumber, PhoneNumber mobilenumber) : base()
    {
        Id = id;
        Name = name;
        IdentityNumber = identityNumber;
        MobileNumber = mobilenumber;
    }
    public Guid Id { get; set; }
    public string? Name { get;  set; }
    public string? IdentityNumber { get;  set; }
    public PhoneNumber? MobileNumber { get;  set; }
    public Guid? SocietyId { get; set; }
    public Society? Society { get; set; }
    public DateTime BoardStartDate { get; set; } 
    public DateTime BoardEndDate { get; set; } 
    public string? Email { get; set; }
    internal void Update(string name, string identityNumber, PhoneNumber mobilenumber)
    {
        Name = name;
        IdentityNumber = identityNumber;
        MobileNumber = mobilenumber;
    }
}
