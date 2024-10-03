using System.ComponentModel.DataAnnotations;

namespace Waqfi.LocalNIC.Entities;
public enum TargetGenders
{
    [Display(Name = "Male")]
    Male = 1,
    [Display(Name = "Female")]
    Female = 2,
    [Display(Name = "Both")]
    Both = 3
}
