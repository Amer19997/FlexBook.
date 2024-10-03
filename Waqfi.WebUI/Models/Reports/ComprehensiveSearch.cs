namespace WebUI.Models.Reports;

public class ComprehensiveSearch
{
    public List<Client.GetDonationMethodQueryResult> DonationMethodList { get; set; }
    public List<Client.MasaratItemDto> GetMasaratListResult { get; set; }
    public List<Client.GetProductSizeQueryResult> GetProductSizeList { get; set; }
    public List<Client.GetProductPaymentStatusItem> GetProductPaymentStatus { get; set; }
    public List<Client.GetProductTypesResult> UnitTypies { get; set; }
}
