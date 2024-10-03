namespace Waqfi.LocalNIC.Entities;

public class District
{
    public Guid Id { get; set; }
    public Guid? CityId { get;  set; }
    public DescriptionLocalized? Name { get;  set; }
    public int? OrderIndex { get;  set; }
    public bool? IsActive { get;  set; }
    public List<ProviderAddress> ProviderAddresses { get; set; }
    public City? City { get;  set; }
}