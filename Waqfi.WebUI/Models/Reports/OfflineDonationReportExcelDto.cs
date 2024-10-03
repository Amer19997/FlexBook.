using DocumentFormat.OpenXml.Drawing.Charts;
using Fingers10.ExcelExport.Attributes;

namespace WebUI.Models.Reports;

public class OfflineDonationReportExcelDto
{
    [IncludeInReport(Order = 1)]
    public int Serial { get; set; }

    [IncludeInReport(Order = 2)]
    public string ProductName { get; set; }

    [IncludeInReport(Order = 3)]
    public string ProviderName { get; set; }

    [IncludeInReport(Order = 4)]
    public string Amount { get; set; }

    [IncludeInReport(Order = 5)]
    public string ProductApprovalDate { get; set; }

    [IncludeInReport(Order = 6)]
    public string IsParallelProduct { get; set; }

    [IncludeInReport(Order = 7)]
    public int? ProductNumber { get; set; }
}
