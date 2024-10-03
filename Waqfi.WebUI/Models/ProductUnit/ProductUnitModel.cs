using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.ProductUnit;

public class ProductUnitModel
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(70, ErrorMessage = "اسم الوحدة غير صحيح")]
    public string NameAr { get; set; }


    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(70, ErrorMessage = "اسم الوحدة غير صحيح")]
    public string NameEn { get; set; }
}
