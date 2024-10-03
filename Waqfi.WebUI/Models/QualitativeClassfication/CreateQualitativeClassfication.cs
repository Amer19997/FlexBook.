using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.QualitativeClassfication;

public class CreateQualitativeClassfication
{
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string NameAr { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string NameEn { get; set; }
}
