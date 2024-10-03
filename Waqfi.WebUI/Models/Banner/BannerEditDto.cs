using System.ComponentModel.DataAnnotations;
using WebUI.Client;

namespace WebUI.Models.Banner;

public class BannerEditDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(200, ErrorMessage = "اسم البانر غير صحيح")]
    public string NameAr { get; set; }


    [MaxLength(300, ErrorMessage = "وصف البانر غير صحيح")]
    public string? DescriptionArbic { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(200, ErrorMessage = "اسم البانر غير صحيح")]
    public string NameEn { get; set; }

    [MaxLength(300, ErrorMessage = "وصف البانر غير صحيح")]
    public string? DescriptionEnglish { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public DateTimeOffset StartAt { get; set; }
    public DateTimeOffset? EndAt { get; set; }
    public int Periorty { get; set; }

    [Url(ErrorMessage = "يجب ادخال رابط صحيح")]
    public string? URL { get; set; }
    public BannerStatus status { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public IFormFile ImageDto { get; set; }

    public bool IconIsEdit { get; set; }
    public bool IconMobileIsEdit { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public Guid ProductId { get; set; }  

    public IFormFile? PhoneImage { get; set; }
    public bool IsBannerVideo { get; set; }  
}
