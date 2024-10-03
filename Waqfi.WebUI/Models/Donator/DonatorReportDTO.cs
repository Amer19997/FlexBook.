using Fingers10.ExcelExport.Attributes;

namespace WebUI.Models.Donator;

public class DonatorReportDTO
{
    [IncludeInReport(Order =1)]
    public int Serial { get; set; }

    [IncludeInReport(Order =2)]
    public string DonatorName { get; set; }

    [IncludeInReport(Order = 3)]
    public string Email { get; set; }

    [IncludeInReport(Order = 4)]
    public string MobileNumber { get; set; }

    [IncludeInReport(Order = 5)]
    public double TotalAmount { get; set; }

    [IncludeInReport(Order = 6)]
    public int TotalCount { get; set; }

  
}
