namespace WebUI.Models.Product;

public class ProductRequestApprovalModel
{
    public Guid Id { get; set; }
    public string? ApprovalNotes { get; set; }
    public int Percentage { get; set; }
    public bool ApperOnBanar { get; set; }
    public IFormFile? AttachedFile { get; set; }
    public bool IsParallelProduct { get; set; }
    public int ProductType { get; set; }
}
