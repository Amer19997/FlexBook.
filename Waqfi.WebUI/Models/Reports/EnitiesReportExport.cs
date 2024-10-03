using System.Text;
using Fingers10.ExcelExport.Attributes;

namespace WebUI.Models.Reports;

public class EnitiesReportExport
{
    [IncludeInReport(Order = 1)]
    public int Serial { get; set; }

    [IncludeInReport(Order = 2)]
    public string ProviderName { get; set; }

    [IncludeInReport(Order = 3)]
    public string IdentityNumber { get; set; }

    [IncludeInReport(Order = 4)]
    public double? TotalProductsAmount { get; set; }
    [IncludeInReport(Order = 5)]
    public double? TotalOnlineDonations { get; set; }
    [IncludeInReport(Order = 6)]
    public double? TotalGatheredDonations { get; set; }
    [IncludeInReport(Order = 7)]
    public double? TotalTopGiversAmount { get; set; }
    [IncludeInReport(Order = 8)]
    public double? meritAmount { get; set; }
    [IncludeInReport(Order = 9)]
    public double? TransferdAmount { get; set; }
    [IncludeInReport(Order = 10)]

    public double? RemainingAmount { get; set; }


    [IncludeInReport(Order = 11)]
    public string ProductsAndBanks
    {
        get
        {
            if (Products == null || Products.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();

            foreach (ProductDto product in Products)
            {
                sb.AppendFormat("{0} ({1}, {2}, {3})\n", product.ProductName, product.ProductType, product.BankName, product.BankIban);
            }

            return sb.ToString().TrimEnd('\n');
        }
    }
    [IncludeInReport(Order = 12)]

    public int? ProductNumber { get; set; }
    public List<ProductDto> Products { get; set; }

}
public class ProductDto
{
    public string ProductName { get; set; }
    public string ProductType { get; set; }
    public string BankName { get; set; }
    public string BankIban { get; set; }
}