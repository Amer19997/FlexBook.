using DocumentFormat.OpenXml.Drawing.Charts;
using Fingers10.ExcelExport.Attributes;

namespace WebUI.Models.NetworkDonator;

public class NetworkDonatorReport
{
    [IncludeInReport(Order = 1)]
    public int Serial { get; set; }

    [IncludeInReport(Order = 2)]

    public string FullName { get; set; }

    [IncludeInReport(Order = 3)]
    public string Email { get; set; }

    [IncludeInReport(Order = 4)]
    public int TotalDonateCount { get; set; }

    [IncludeInReport(Order = 5)]
    public double TotalDonateAmount { get; set; }

    [IncludeInReport(Order = 7)]
    public string MobileNumber { get; set; }
}
