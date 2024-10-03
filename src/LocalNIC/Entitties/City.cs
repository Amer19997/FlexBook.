namespace Waqfi.LocalNIC.Entities;
public class City
{
    public Guid Id { get; set; }
    public Guid? RegionId { get; set; }
    public DescriptionLocalized? Name { get; set; }
    public int? OrderIndex { get; set; }
    public bool? IsActive { get; set; }
    public Region? Region { get; set; }
    public List<District> Districts { get; set; }
    public List<ProviderAddress> ProviderAddresses { get; set; }
    public List<ProviderAddress> ProviderAddressesBase { get; set; }


}
