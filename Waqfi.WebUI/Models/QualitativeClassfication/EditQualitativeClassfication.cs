using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.QualitativeClassfication;

public class EditQualitativeClassfication
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string NameAr { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string NameEn { get; set; }
}
