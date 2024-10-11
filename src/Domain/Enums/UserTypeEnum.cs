using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlexBook.Domain.Enums;
public enum UserTypeEnum
{
    [Display(Name = "Student")]
    Student = 1,

    [Display(Name = "Instructor")]
    Instructor = 2,

    [Display(Name = "Dashboard User")]
    DashboardUser = 3
}