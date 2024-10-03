using DocumentFormat.OpenXml.Drawing.Charts;
using Fingers10.ExcelExport.Attributes;

namespace WebUI.Models.Reports;

public class ProductsReport
{
    [IncludeInReport(Order = 1)]
    public int Serial { get; set; }

    [IncludeInReport(Order = 2)]
    public string ProductName { get; set; }

    [IncludeInReport(Order = 3)]
    public string ProviderName { get; set; }

    //[IncludeInReport(Order = 4)]
    //public string BankName { get; set; }

    [IncludeInReport(Order = 4)]
    public string IBan { get; set; }

    [IncludeInReport(Order = 5)]
    public double? TotalAmountOfProduct { get; set; }
    [IncludeInReport(Order = 6)]
    public double? TotalOnline { get; set; }
    [IncludeInReport(Order = 7)]
    public double? RemainingAmount { get; set; }
    [IncludeInReport(Order = 8)]
    public double? OfflineTotal { get; set; }
    [IncludeInReport(Order = 9)]
    public double? TopGiversTotal { get; set; }
    [IncludeInReport(Order = 10)]
    public double? TotalDonationManasa { get; set; }
    [IncludeInReport(Order = 11)]
    public double? TotalCollectedAmount { get; set; }

    [IncludeInReport(Order = 12)]
    public double? MeritTotal { get; set; }

    [IncludeInReport(Order = 13)]
    public string IsParallelProduct { get; set; }

    [IncludeInReport(Order = 14)]
    public int? ProductNumber { get; set; }

}
