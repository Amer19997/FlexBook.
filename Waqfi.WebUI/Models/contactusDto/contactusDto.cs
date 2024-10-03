using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.contactusDto;

public class contactusDto
{
    [Required(ErrorMessage = "هذا الحقل إجبارى")]

    public string AddressAr { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]

    public string AddressEn { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MinLength(10, ErrorMessage="يجب ان يختوى رقم الهاتف من 10 ارقام ")]
    public string phone { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [Url(ErrorMessage = "يجب ادخال رابط صحيح")]

    public string location{ get; set; }
}
