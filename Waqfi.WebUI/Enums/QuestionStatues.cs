using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebUI.Enums;

public enum Questionstat
{
    [Display(Name = "غير فعال")]
    DisActive = 1,
    [Display(Name = "فعال")]

    Active = 2,
}
