namespace Waqfi.LocalNIC.Entities;

public class ProviderAddress 
{
    public Guid? RegionId { get; set; }

    public Region? Region { get;  set; }
    public Guid? CityId { get; set; }

    public City? City { get;  set; }
    public string? DetailedAddress { get;  set; }
    public string? BriefAddress { get;  set; }
    public District? District { get;  set; }
    public string? Street { get;  set; }
    public string? BuildingNumber { get;  set; }
    public string? ZipCode { get;  set; }
    public string? PostalCode { get;  set; }
    public string? SideNumber { get;  set; }
    public Guid? CityBaseId { get; set; }

    public City? CityBase { get;  set; }
    public Guid? Id { get;  set; }
    public Guid? SocietyId { get; set; }
    public Society? Society { get; set; }
  
}
