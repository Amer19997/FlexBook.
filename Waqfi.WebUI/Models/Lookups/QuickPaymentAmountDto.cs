using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Payment;

public class QuickPaymentAmountDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [Range(1, 9999, ErrorMessage = "يجب ادخال قيمة تبرع صحيحة بحد أقصى 4 أرقام")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "يجب ادخال قيمة تبرع صحيحة")]
    public decimal Amount { get; set; }
}
