using WebUI.Client;

namespace WebUI.Models.Reports;

public class EntitiesReportSearch
{
    public List<Int32LookupDto> GetDonationMethodQueryResult { get; set; }
    public string? Contains { get; set; }
    public string? ProviderType { get; set; }
    public string? PaymentStatusWithin { get; set; }
    public string? VerfiedDateFrom { get; set; }
    public string? VerfiedDateTo { get; set; }
    public string? RegestrationDateFrom { get; set; }
    public string? RegestrationDateTo { get; set; }
    public string? RegestrationEndDateFrom { get; set; }
    public string? RegestrationEndDateTo { get; set; }
    public string? PeriodFrom { get; set; }
    public string? PeriodTo { get; set; }
    public int PageNumber { get; set; } = 1;
    public int? PageSize { get; set; }

}
