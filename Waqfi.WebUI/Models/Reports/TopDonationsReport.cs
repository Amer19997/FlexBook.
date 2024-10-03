using System.ComponentModel.DataAnnotations;
using DocumentFormat.OpenXml.Drawing.Charts;
using Fingers10.ExcelExport.Attributes;

namespace WebUI.Models.Reports;

public class TopDonationsReport
{
    [Display(Name = "مسلسل")]
    [IncludeInReport(Order = 1)]
    public int Serial { get; set; }

    [Display(Name = "اسم المتبرع")]
    [IncludeInReport(Order = 2)]
    public string TopDonatorName { get; set; }

    [Display(Name = "البريد الالكتروني")]
    [IncludeInReport(Order = 3)]
    public string Email { get; set; }

    [Display(Name = "رقم الجوال")]
    [IncludeInReport(Order = 4)]
    public string MobileNumber { get; set; }

    [Display(Name = "المسار")]
    [IncludeInReport(Order = 5)]
    public string MasaratName { get; set; }

    [Display(Name = "المنتج")]
    [IncludeInReport(Order = 6)]
    public string ProductName { get; set; }
    
    [Display(Name = "اسم الجهة")]
    [IncludeInReport(Order = 7)]
    public string ProviderName { get; set; }

    [Display(Name = "قيمة التبرع")]
    [IncludeInReport(Order = 8)]
    public string DonationAmount { get; set; }

    [Display(Name = "تاريخ التبرع")]
    [IncludeInReport(Order = 9)]
    public string DonationDate { get; set; }

    [Display(Name = "رقم المنتج")]
    [IncludeInReport(Order = 9)]
    public int? ProductNumber { get; set; }
}
