using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Provider;

public class AssociationUpdate
{
    
    public Guid AssocationId { get; set; }
    public BasicAssocationDto BasicInfoDto { get; set; }
    public AddressAssocationDto AddressInfo { get; set; }
    public ContactAssocationDto ContactInfo { get; set; }
    public SocialAssocationDto SocialInfo { get; set; }
    public BankAssocationDto BankInfoList { get; set; }
}
public class AddressAssocationDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public Guid? Regoin { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public Guid? City { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(200, ErrorMessage = "الحد الأقصى 200 حرف")]
    public string? DetailedAddress { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(8, ErrorMessage = "الحد الأقصى 8 حرف")]
    public string? BriefAddress { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(4, ErrorMessage = "الحد الأقصى 4 ارقام")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "يجب إدخال ارقام فقط")]
    public string? BuildingNumber { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(150, ErrorMessage = "الحد الأقصى 150 حرف")]
    public string? Street { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(4, ErrorMessage = "الحد الأقصى 4 ارقام")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "يجب إدخال ارقام فقط")]
    public string? SideNumber { get; set; }
    public Guid? District { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(5, ErrorMessage = "الحد الأقصى 5 ارقام")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "يجب إدخال ارقام فقط")]
    public string? PostalCode { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public Guid? CityLookUp { get; set; }
}
public class BankAssocationDto
{
    public List<BankAssociationItemDto> BankInfoList { get; set; }
}
public class BankAssociationItemDto
{
    public Guid Id { get; set; }
    public Guid Bank { get; set; }
    public string BankName { get; set; }
    public string BankAccountNumber { get; set; }
    public string IbanAccountNumber { get; set; }
    public string BeneficiaryName { get; set; }
    public bool CanEdit { get; set; }

}
public class BasicAssocationDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(100, ErrorMessage = "الحد الأقصى 100 حرف")]
    public string? AssociationName { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [StringLength(10, ErrorMessage = "الحد الأقصى 10 ارقام")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "يجب إدخال ارقام فقط")]
    public string? AssociationNumber { get; set; }
    public string? LicenseStartDate { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public string? LicenseEndDate { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [StringLength(10, ErrorMessage = "الحد الأقصى 10 ارقام")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "يجب إدخال ارقام فقط")]
    public string? CommercialRegisterNo { get; set; }
    public int? Gender { get; set; }
    public DateTimeOffset? JoiningDate { get; set; }
}
public class ContactAssocationDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(12, ErrorMessage = "الحد الأقصى 12 ارقام")]
    [RegularExpression("(^9665([0-9]{8,8})+)", ErrorMessage = "رقم الجوال غير صحيح")]
    public string? MobileNumber { get; set; }
    [MaxLength(12, ErrorMessage = "الحد الأقصى  12ارقام")]
    [RegularExpression("(^9665([0-9]{8,8})+)", ErrorMessage = "رقم الهاتف غير صحيح")]
    public string? LandLineNumber { get; set; }
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    [MaxLength(100, ErrorMessage = "الحد الأقصى 100 حرف")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "البريد الإلكترونى غير صحيح")]
    public string? Email { get; set; }
    [MaxLength(100, ErrorMessage = "الحد الأقصى 100 حرف")]
    ///website
    public string? Website { get; set; }
}
public class SocialAssocationDto
{
    public Guid Id { get; set; }
    public string? Twitter { get; set; }
    public string? Instgram { get; set; }
    public string? TickTok { get; set; }
    public string? Youtube { get; set; }
    public string? Snapchat { get; set; }
}
