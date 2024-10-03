using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Masarat;

public class MasaratDto
{
    public Guid Id { get; set; }

    [Required (ErrorMessage ="هذا الحقل إجبارى")]
    [MaxLength(70 ,ErrorMessage = "اسم المسار غير صحيح")]
    public string NameAr { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(140, ErrorMessage = "وصف المسار غير صحيح")]
    public string DescriptionArbic { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(70, ErrorMessage = "اسم المسار غير صحيح")]
    public string NameEn { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(140, ErrorMessage = "وصف المسار غير صحيح")]
    public string DescriptionEnglish { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public IFormFile IconDto { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public List<IFormFile> OtherImageDto { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public List<IFormFile> OtherImages { get; set; }


    public bool IconIsEdit { get; set; } = false;

    public bool OtherImagesIsEdit { get; set; } = false;
    public double listSize { get; set; }
    public double ListCount { get; set; }


}
