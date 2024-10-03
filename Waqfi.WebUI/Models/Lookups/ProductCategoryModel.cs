using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Lookups;

public class ProductCategoryModel
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(70, ErrorMessage = "اسم فئه المستهدفه غير صحيح")]
    public string NameAr { get; set; }


    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(70, ErrorMessage = "اسم فئه المستهدفه غير صحيح")]
    public string NameEn { get; set; }
}
