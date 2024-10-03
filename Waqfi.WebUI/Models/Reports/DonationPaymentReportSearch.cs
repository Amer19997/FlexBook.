using WebUI.Client;

namespace WebUI.Models.Reports;

public class DonationPaymentReportSearch
{
    public PaymentStatus? RequestStatus { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
}
