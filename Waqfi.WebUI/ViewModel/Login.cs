using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModel;

public class Login
{

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "برجاء ادخال بريد الكتروني صحيح")]
    public string Email { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string Password { get; set; }

}
