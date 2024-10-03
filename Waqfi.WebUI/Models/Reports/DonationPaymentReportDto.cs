using DocumentFormat.OpenXml.Drawing.Charts;
using Fingers10.ExcelExport.Attributes;

namespace WebUI.Models.Reports;

public class DonationPaymentReportDto
{

    [IncludeInReport(Order = 1)]
    public int Serial { get; set; }

    [IncludeInReport(Order = 2)]
    public string DonationPaymentNumber { get; set; }
    [IncludeInReport(Order = 3)]

    public string PaymentStatus { get; set; }
    [IncludeInReport(Order = 4)]

    public string Amount { get; set; }
    [IncludeInReport(Order = 5)]

    public string DateTimeDonation { get; set; }
    [IncludeInReport(Order = 6)]

    public string PaymentMethod { get; set; }
    [IncludeInReport(Order = 7)]

    public string ProductProvider { get; set; }

    [IncludeInReport(Order = 8)]

    public int? ProductNumber { get; set; }
}
