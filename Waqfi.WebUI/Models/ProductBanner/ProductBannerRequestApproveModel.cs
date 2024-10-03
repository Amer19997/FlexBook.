using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Models.ProductBanner;

public class ProductBannerRequestApproveModel
{
    [BindProperty]
    [Required(ErrorMessage = "هذا الحقل إلزامي")]
    public string priority { get; set; }
    public string[] Prioritys = new[] { "1", "2", "3"};
    
    public Guid ProductId { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string Publishdate { get; set; } 


    public string? Disappearancedate { get; set; }

   
    
}
