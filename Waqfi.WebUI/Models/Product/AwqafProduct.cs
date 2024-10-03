using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;

namespace WebUI.Models.Product;

public class AwqafProductDto
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string ProductNameAr { get; set; }
    
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string ProductNameEng { get; set; }
    
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public Guid MasarId { get; set; }
    
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public Guid MasarFileId { get; set; }
    
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [Range(1, 999999999.99, ErrorMessage = "الرقم المدخل غير صحيح")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "الرقم المدخل غير صحيح")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public int DonationMethod { get; set; }

    [RequiredIf("DonationMethod == 1", ErrorMessage = "هذا الحقل إلزامي")]
    public Guid? UnitType { get; set; }

    [RequiredIf("DonationMethod == 1" , ErrorMessage = "هذا الحقل إلزامي")]
    [Range(1, 999999999.99, ErrorMessage = "الرقم المدخل غير صحيح")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$",ErrorMessage = "الرقم المدخل غير صحيح")]
    public decimal? UnitPrice { get; set; }

    [RequiredIf("DonationMethod == 1", ErrorMessage = "هذا الحقل إلزامي")]
    [Range(1, 999999999.99, ErrorMessage = "الرقم المدخل غير صحيح")]
    public int? UnitCount { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string ForWhomAr { get; set; }
    
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string ForWhomEn { get; set; }
    public string? TheTypeOfBeneficiaryAr { get; set; }
    public string? TheTypeOfBeneficiaryEn { get; set; }
    public string? WhatDoesOneDeviceOfferAr { get; set; }
    public string? WhatDoesOneDeviceOfferEn { get; set; }
    public string? WhyDoISupportThemAr { get; set; }
    public string? WhyDoISupportThemEn { get; set; }
    public string? HowDoISupportThemAr { get; set; }
    public string? HowDoISupportThemEn { get; set; }
}
