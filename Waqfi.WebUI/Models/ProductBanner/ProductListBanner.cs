using WebUI.Client;

namespace WebUI.Models.ProductBanner;

public class ProductListBanner
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<GetApproveProductQueryDto> ProductsRequest { get; set; }
}



