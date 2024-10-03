using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Product;

public class ApprovedProductModel
{
    public Guid Id { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string? ForWhomIsThisProductEn { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string? ForWhomIsThisProductAr { get; set; }
    public string? WhyDoISupportThemAr { get; set; }
    public string? WhyDoISupportThemEn { get; set; }
    public string? HowDoISupportThemAr { get; set; }
    public string? HowDoISupportThemEn { get; set; }
    public string? TheTypeOfBeneficiariesAr { get; set; }
    public string? TheTypeOfBeneficiariesEn { get; set; }

    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid MasarId { get; set; }
    public List<Guid> ProductCategoriesIds { get; set; }
    public List<Guid> SeasonsIds { get; set; }
    public int Gender { get; set; }

    public Guid? ImageId { get; set; }
    public string? DesktopImageUrl { get; set; }
    public string? MobileImageUrl { get; set; }
    public IFormFile? DesktopImage { get; set; }
    public IFormFile? MobileImage { get; set; }

    public bool DesktopImageIsEdit { get; set; } = false;

    public bool MobileImageIsEdit { get; set; } = false;
    public bool IsActive { get; set; }

}
