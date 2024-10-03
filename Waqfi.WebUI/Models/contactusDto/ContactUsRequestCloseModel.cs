using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.contactusDto;

public class ContactUsRequestCloseModel
{
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(1000, ErrorMessage = "يجب ادخال الاغلاق بشكل صحيح")]
    public string Message { get; set; }
    public string Id { get; set; }
}
