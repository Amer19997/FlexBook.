using WebUI.Client;

namespace WebUI.Filters;

public class filterRequestProductsDto
{
    public string? ProductName { get; set; }
    public string? EntityName { get; set; }
    public ProductTypeEnum? ProductType { get; set; }
    public ProductPaymentStatus? ProductPaymentStatus { get; set; }
    public string? ProductsType { get; set; }
    public Guid? Massar { get; set; }
    public Guid? City { get; set; }
    public Guid? sesson { get; set; }
    public Guid? TargetGroup { get; set; }
    public TargetGenders? Gender { get; set; }
    public RequestStatus? Status { get; set; }
    public string? Providers { get; set; }

    public string? Apperonhomepage { get; set; }
    public int? BidPercentage { get; set; }
    public int IsBarallelProduct { get; set; }

}
