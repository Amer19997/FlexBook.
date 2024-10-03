using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.ProductType;

public class ProductTypeModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(50, ErrorMessage = "اسم الجنس المخدوم غير صحيح")]
    public string NameAr { get; set; }


    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(50, ErrorMessage = "اسم الجنس المخدوم غير صحيح")]
    public string NameEn { get; set; }
}
