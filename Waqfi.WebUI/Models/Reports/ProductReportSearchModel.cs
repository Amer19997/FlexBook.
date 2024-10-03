namespace WebUI.Models.Reports;

public class ProductReportSearchModel
{
    public string? GehaName { get; set; }
    public string? Contain { get; set; }
    public string? DonationMethodID { get; set; }
    public string? MasarId { get; set; }
    public string? ProductSize { get; set; }
    public string? ProductType { get; set; }
    public string? ProductPaymentStatus { get; set; }
    public string? UnitType { get; set; }
    public string? PeriodFrom { get; set; }
    public string? PeriodTo { get; set; }
    public string? VerfiedDateFrom { get; set; }
    public string? VerfiedDateTo { get; set; }
    public string? RegestrationDateFrom { get; set; }
    public string?RegestrationDateTo { get; set; }
    public int ParallelProduct { get; set; }
    public int PageNumber { get; set; } = 1;
    public int? PageSize { get; set; }
    public int? ProductNumber { get; set; }

}
