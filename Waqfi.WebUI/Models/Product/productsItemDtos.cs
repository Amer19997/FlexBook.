using WebUI.Client;

namespace WebUI.Models.Product;

public class ProductList
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<ProductItemDto> ProductsRequest { get; set; }
}
public class productsItemDtos
{
    public Guid Id { get; set; }
    public string? ProductName { get; set; }
    public string? EntityName { get; set; }
    public ProductTypeEnum? ProductType { get; set; }
    public string? Massar { get; set; }
    public string? City { get; set; }
    public string? TotalAmount { get; set; }
    public string? Status { get; set; }

}
