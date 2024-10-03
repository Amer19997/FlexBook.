using System.ComponentModel.DataAnnotations;
using static WebUI.ViewModel.UserResultApi;

namespace WebUI.Enums;

public enum RequestStatusEnum
{
    [Display(Name = "Draft")]
    Draft = 0,
    [Display(Name = " انتظار الاعتماد")]
    Pending = 1,
    [Display(Name = "Approved")]
    Approved = 2,
    [Display(Name = "مرفوضة")]
    Rejected = 3,
    [Display(Name = " إعادة لتعديل البيانات")]
    New = 4,

    [Display(Name = "DraftVersion")]
    DraftVersion = 5,
    [Display(Name = "PendingVersion")]
    PendingVersion = 6,
    [Display(Name = "RejectedVersion")]
    RejectedVersion = 7,
    [Display(Name = "ReturnedVersion")]
    ReturnedVersion = 8,
    [Display(Name = "Deprecated")]
    Deprecated = 9
}
public enum Attachments
{
    OtherAttachment = 0 
}
