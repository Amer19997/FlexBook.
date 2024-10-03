
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FlexBook.Domain.Enums;

[Flags]
public enum TargetGenders : byte
{
    [Display(Name = "Male")]
     Male = 1,
    [Display(Name = "Female")]
    Female =2,
    [Display(Name = "Both")]
    Both =3
}
