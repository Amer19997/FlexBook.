namespace WebUI.Models.AboutUs;

public class SiteContentDto
{
    
    public string WaqfiPlatformARDescsription { get; set; }
    public string WaqfiPlatformEnDescription { get; set; }
    public string IdeaArDescription { get; set; }
    public string IdeaEnDescription { get; set; }
    public string PlatformExpectedEffectArDescription { get; set; }
    public string PlatformExpectedEffectEnDescription { get; set; }
    public string TargetArDescription { get; set; }
    public string TargetEnDescription { get; set; }
    public string ProductArDescription { get; set; }
    public string ProductEnDescription { get; set; }
    public string SiteContentImage { get; set; }
    public IFormFile? ImageDto { get; set; }
    public bool IconIsEdit { get; set; } = false;
}
