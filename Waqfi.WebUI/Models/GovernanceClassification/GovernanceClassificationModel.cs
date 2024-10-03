﻿using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.GovernanceClassification;

public class GovernanceClassificationModel
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(50, ErrorMessage = "اسم الوحدة غير صحيح")]
    public string NameAr { get; set; }


    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(50, ErrorMessage = "اسم الوحدة غير صحيح")]
    public string NameEn { get; set; }
}
