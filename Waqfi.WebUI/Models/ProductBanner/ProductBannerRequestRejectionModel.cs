using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.ProductBanner;

public class ProductBannerRequestRejectionModel
{
    [Required]
    public string RequestId { get; set; }

    [Required(ErrorMessage = "يجب ادخال سبب الرفض بشكل صحيح", AllowEmptyStrings = false)]

    [MaxLength(2500, ErrorMessage = "يجب ادخال سبب الرفض بشكل صحيح")]
    public string Notes { get; set; } 
}
