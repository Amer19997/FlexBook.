using System.ComponentModel.DataAnnotations;

namespace WebUI.Enums;

public enum ContactUsStatues
{
    [Display(Name = " طلب مفتوح")]

    Open = 1,
    [Display(Name = "طلب مغلق")]

    Close = 2,
    hold =3 ,
    Waitingcustomer = 4 

}
