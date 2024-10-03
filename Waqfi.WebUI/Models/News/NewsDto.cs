using System.ComponentModel.DataAnnotations;
using WebUI.Client;

namespace WebUI.Models.News;

public class NewsDto
{
    public Guid NewsId { get; set; }

    [Required (ErrorMessage ="هذا الحقل إجبارى")]
    [MaxLength(150 ,ErrorMessage = "عنوان الخبر غير صحيح")]
    public string TitleAr { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(150, ErrorMessage = "عنوان الخبر غير صحيح")]
    public string TitleEn { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(300, ErrorMessage = "The max chars on this field is 300")]
    public string SummaryAr { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(300, ErrorMessage = "The max chars on this field is 300")]
    public string SummaryEn { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(2500, ErrorMessage = "The max chars on this field is 2500")]
    public string DetailsAr { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(2500, ErrorMessage = "The max chars on this field is 2500")]
    public string DetailsEn { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public int NewsStatus { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public IFormFile ImageDto { get; set; }
    public string ImgUrl { get; set; }
    public Guid? ImageId { get; set; }
    public bool EditImage { get; set; } = false;
}
