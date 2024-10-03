using WebUI.Client;

namespace WebUI.Models.Reports;

public class ReportOfflineDonationDto
{
    public int? PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<GetOfflineDonationReportListQueryResult> OfflineDonationsList { get; set; }
}
