using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Product;

public class ProductRequestReturnModel
{
    [Required]
    public string RequestId { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(2500, ErrorMessage = "يجب ادخال سبب الأعادة بشكل صحيح")]
    public string Notes { get; set; }

    //public List<StepDto> Steps { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string ListReturnItem { get; set; }
}
