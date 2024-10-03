using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Product;

public class ProductRequestRejectionModel
{
    [Required]
    public string RequestId { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]

    [MaxLength(2500, ErrorMessage = "يجب ادخال سبب الرفض بشكل صحيح")]
    public string Notes { get; set; }
}
