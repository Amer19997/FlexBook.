using WebUI.Client;

namespace WebUI.Models.ApprovedProduct;

public class ApprovedProductDTO
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<ProductItemApproveDTO> ProductsRequest { get; set; }
}
