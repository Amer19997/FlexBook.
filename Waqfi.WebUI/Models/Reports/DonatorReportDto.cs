using WebUI.Client;

namespace WebUI.Models.Reports;

public class DonatorReportDto
{
    public int? PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<GetDonationQueryResultList> ProductsRequest { get; set; }
}
