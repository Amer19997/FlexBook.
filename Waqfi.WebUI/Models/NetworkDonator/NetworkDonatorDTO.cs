using WebUI.Client;

namespace WebUI.Models.NetworkDonator;

public class NetworkDonatorDTO
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<GetAllNetworkDonatorResult> ProductsRequest { get; set; }
}
