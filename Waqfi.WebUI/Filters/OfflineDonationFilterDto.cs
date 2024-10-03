using WebUI.Client;

namespace WebUI.Filters;

public class OfflineDonationFilterDto
{
    public Guid? Providers { get; set; }
    public Guid? Products { get; set; }
    public RequestStatus? Status { get; set; }
}
