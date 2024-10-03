using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.AboutusDto;

public class AboutusDto
{
    [Required(ErrorMessage = "هذا الحقل إجبارى")]
    public IFormFile IconDto { get; set; }

    public string ImageUrl { get; set; }
    public string AboutWagfiAr { get; set; }  
    public string AboutWagfiEn { get; set; }  

    public string WagfiIdeaAr { get; set; }  
    public string WagfiIdeaEn { get; set; }  
    public string WagfitargetAR { get; set; }  
    public string WagfitargetEN { get; set; }  
    public string WagfiproductAR{ get; set; }  
    public string WagfiproductEN{ get; set; }  
    public string WagfiEffectAR { get; set; }  
    public string WagfiEffectEN { get; set; }

    public bool IconIsEdit { get; set; } = false;

}
