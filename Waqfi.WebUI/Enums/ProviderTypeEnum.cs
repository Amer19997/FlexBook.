using System.ComponentModel.DataAnnotations;
using static WebUI.ViewModel.UserResultApi;

namespace WebUI.Enums;

public enum ProviderTypeEnum
{
    [Display(Name = "مؤسسة وقفية")]
    Association = 1,
    [Display(Name = "جمعية  أهلية")]
    Society = 2
}
