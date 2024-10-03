using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Seasons;

public class SeasonEditModel
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(70, ErrorMessage = "اسم الموسم غير صحيح")]
    public string NameAr { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(70, ErrorMessage = "اسم الموسم غير صحيح")]
    public string NameEn { get; set; }
    [MaxLength(140, ErrorMessage = "ادخل وصف صحيح")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string StartAt { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string EndAt { get; set; }
}
