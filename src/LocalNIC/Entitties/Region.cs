namespace Waqfi.LocalNIC.Entities;

public class Region
{
    public Guid Id { get; set; }
    public DescriptionLocalized? Name { get; private set; }
    public string? PostalCode { get; private set; }
    public int? OrderIndex { get; private set; }
    public bool? IsActive { get; private set; }
    public List<City> Cities { get; set; }
    public List<ProviderAddress> ProviderAddresses { get; set; }
}
