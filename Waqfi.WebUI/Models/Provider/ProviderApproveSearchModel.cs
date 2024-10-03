using WebUI.Client;

namespace WebUI.Models.Provider;

public class ProviderApproveSearchModel
{
    public string? Name { get; set; }
    public string? RegisterNum { get; set; }
    public ProviderTypeEnum? Type { get; set; }
    public TargetGenders? Gender { get; set; }
    public DateTime? JoinFromDate { get; set; }
    public DateTime? JoinToDate { get; set; }
    public DateTime? LicenseFromDate { get; set; }
    public DateTime? LicenseToDate { get; set; }

}
