using WebUI.Client;

namespace WebUI.Models.OfflineDonation;

public class OfflineDonationsDto
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int TotalCount { get; set; }

    public List<GetOfflineDonationListQueryResult> OfflineDonationRequests { get; set; }
}
