using DocumentFormat.OpenXml.Drawing.Charts;
using Fingers10.ExcelExport.Attributes;

namespace WebUI.Models.Donator;

public class DonatorDetailsReport
{
    [IncludeInReport(Order = 1)]
    public int Serial { get; set; }
    [IncludeInReport(Order = 2)]
    public string DonatorName { get; set; }

    [IncludeInReport(Order = 3)]
    public string ProductName { get; set; }


    [IncludeInReport(Order = 4)]
    public string ProviderName { get; set; }

    [IncludeInReport(Order = 5)]
    public string Masar { get; set; }

    [IncludeInReport(Order = 6)]
    public double? Amount { get; set; }

    [IncludeInReport(Order = 7)]
    public string DonationDate { get; set; }

    [IncludeInReport(Order = 8)]
    public int? ProductNumber { get; set; }
}
