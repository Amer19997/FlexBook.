using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.TopGivers;

public class TopGiversAddDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(100, ErrorMessage = "الاسم غير صحيح")]
    public string TopDonatorName { get; set; }

    [MaxLength(100, ErrorMessage = "يجب أن يكون البريد الإلكتروني بالصيغة التالية: test@test.com")]
    [EmailAddress(ErrorMessage = "يجب أن يكون البريد الإلكتروني بالصيغة التالية: test@test.com")]
    public string? Email { get; set; }

    [MaxLength(9, ErrorMessage = "يجب ادخال رقم جوال صحيح")]
    [RegularExpression(@"^5\d*$", ErrorMessage = "يجب ادخال رقم جوال صحيح")]
    public string? MobileNumber { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public Guid ProductId { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public Guid MasarId { get; set; }

    public bool IsQuickDonation { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public DateTimeOffset? DonationDate { get; set; }

    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [Range(1, 999999999.99, ErrorMessage = "يجب ادخال قيمة تبرع صحيحة")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "يجب ادخال قيمة تبرع صحيحة")]
    public double DonationAmount { get; set; }

    [Required(ErrorMessage = "حقل وثيقة التبرع اجبارى")]
    public IFormFile ImageDto { get; set; }
}
