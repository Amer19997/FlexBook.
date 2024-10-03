namespace WebUI.Models.Reports;

public class ComprehensiveReportSearch
{
    public Guid? MasarId { get; set; }
    public int? UnitType { get; set; }
    public int? ProductType { get; set; }
    public int? ProductSize { get; set; }
    public int? ProductPaymentStatus { get; set; }
    public DateTime? ApprovedFrom { get; set; }
    public DateTime? ApprovedTo { get; set; }
    public string? SearchType { get; set; }
    public string? Contain { get; set; }
    public int IsParallelProduct { get; set; }
    public int? ProductNumber { get; set; }
}
