using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.SocialMedia;

public class SocialMediaModel
{
    [Url(ErrorMessage = "يجب ادخال رابط صحيح")]

    public string? Twitter { get; set; }
    [Url(ErrorMessage = "يجب ادخال رابط صحيح")]

    public string? FaceBook { get; set; }
    [Url(ErrorMessage = "يجب ادخال رابط صحيح")]
    public string? Instragram { get; set; }

    [Url(ErrorMessage = "يجب ادخال رابط صحيح")]
    public string? SnapChat { get; set; }

}
