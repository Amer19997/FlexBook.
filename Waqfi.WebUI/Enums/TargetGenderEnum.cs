using System.ComponentModel.DataAnnotations;
using static WebUI.ViewModel.UserResultApi;

namespace WebUI.Enums;

public enum TargetGenderEnum
{
    [Display(Name = "ذكور")]
    Male = 1,
    [Display(Name = "اناث")]
    Female = 2,
    [Display(Name = "ذكور واناث")]
    Both = 3
}
