using WebUI.Models.Provider;

namespace WebUI.Models.Reports;

public class ReportOfflineDonationSearch
{
    public string? ProviderName { get; set; }
    public string? ProductName { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set;}
    public int IsParallelProduct { get; set; }
    public int? ProductNumber { get; set; }
}
