using WebUI.Client;

namespace WebUI.Models.Provider;

public class ProviderSearchModel
{
    public string? Name { get; set; }
    public ProviderTypeEnum? Type { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public RequestStatus? Status { get; set; }
}
