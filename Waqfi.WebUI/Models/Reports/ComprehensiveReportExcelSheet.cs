using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Fingers10.ExcelExport.Attributes;

namespace WebUI.Models.Reports;

public class ComprehensiveReportExcelSheet
{
    [IncludeInReport(Order = 1)]
    public string ProdcutName { get; set; }

    [IncludeInReport(Order = 2)]
    public string ProviderName { get; set; }

    [IncludeInReport(Order = 3)]
    public string BankName { get; set; }

    [IncludeInReport(Order = 4)]
    public string BankIBAN { get; set; }

    [IncludeInReport(Order = 5)]
    public string DeservedAmount { get; set; }

    [IncludeInReport(Order = 6)]
    public string ProductAmount { get; set; }

    [IncludeInReport(Order = 7)]
    public string TotalOnlinePaid { get; set; }

    [IncludeInReport(Order = 8)]
    public string Average { get; set; }

    [IncludeInReport(Order = 9)]
    public string Remaining { get; set; }

    [IncludeInReport(Order = 10)]
    public string Converted { get; set; }

    [IncludeInReport(Order = 11)]
    public string TotalPaid { get; set; }
    [IncludeInReport(Order = 12)]
    public string IsParallelProduct { get; set; }

    [IncludeInReport(Order = 13)]
    public int? ProductNumber { get; set; }
}
