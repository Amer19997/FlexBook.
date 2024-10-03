using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.contactusDto;

public class ContactUsRequestReplayMessageModel
{
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(1000, ErrorMessage = "يجب ادخال الرد بشكل صحيح")]
    public string Message { get; set; }
    public string Id { get; set; }
    public IFormFile? ConatctUsFile { get; set; }

}
