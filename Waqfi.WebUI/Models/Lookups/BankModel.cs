using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Lookups;

public class BankModel
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(50, ErrorMessage = "اسم نوع البلاغ غير صحيح")]
    public string NameAr { get; set; }


    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(50, ErrorMessage = "اسم نوع البلاغ غير صحيح")]
    public string NameEn { get; set; }


    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(50, ErrorMessage = "كود البنك غير صحيح")]
    public string swiftCode { get; set; }
}
