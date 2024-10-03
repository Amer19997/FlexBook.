using WebUI.Client;

namespace WebUI.Models.AwqafProduct;

public class AwqafProductSearchModel
{
    public string? DonatorName { get; set; }
    public string? ProductName { get; set; }
    public RequestStatus? Status { get; set; }
}
