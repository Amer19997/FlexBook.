using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;

namespace WebUI;

public class CreatePassword
{

    [Required(ErrorMessage = "يجب إدخال كلمه المرور")]
    [MinLength(8, ErrorMessage = "كلمة المرور يجب أن لا تقل عن 8 حروف")]

    [MaxLength(24, ErrorMessage = "كلمة المرور يجب أن لا تزيد عن 64 حروف")]
    [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$@$!%*#?_&.])[A-Za-z\\d$@$!%*#?_&.]{1,}$",
        ErrorMessage = "كلمة المرور يجب أن تتكون من: حرف كبير على الأقل - حرف صغيرعلى الاقل - أرقام ورموز خاصة")]
    
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [MinLength(8, ErrorMessage = "تأكيد كلمة المرور يجب أن لا تقل عن 8 حروف")]
    [MaxLength(24, ErrorMessage = "تأكيد كلمة المرور يجب أن لا تزيد عن 64 حروف")]
    [Required(ErrorMessage = "يجب إدخال تأكيد كلمة المرور")]
    [Compare("Password",ErrorMessage= "كلمة المرور غير مطابقة")]
    [DataType(DataType.Password)]
    public string VerifyPassword { get; set; }

    public string OTP { get; set; }
}
