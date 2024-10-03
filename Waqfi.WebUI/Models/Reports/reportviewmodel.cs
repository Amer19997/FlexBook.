namespace WebUI.Models.Reports;

public class reportviewmodel
{
    public string ProductName { get; set; }

    public string ProviderName { get; set; }
    public string DonatorName { get; set; }
    public string Masar { get; set; }

    public double? Amount { get; set; }

    public string DonationDate { get; set; }
    public int? ProductNumber { get; set; }



    public class reportList
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<reportviewmodel> reportViewModals { get; set; } = new();
    }
    public class filterreportDto
    {
        public string? Title { get; set; }
    }

}
