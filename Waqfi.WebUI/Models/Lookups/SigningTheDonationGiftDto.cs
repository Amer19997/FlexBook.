using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Lookups;

public class SigningTheDonationGiftDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(50, ErrorMessage = "حد أقصى 50 حرف")]
    public string NameAr { get; set; }


    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(50, ErrorMessage = "حد أقصى 50 حرف")]
    public string NameEn { get; set; }
}
