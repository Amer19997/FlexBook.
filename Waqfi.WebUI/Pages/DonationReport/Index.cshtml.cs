using System.Text;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Donator;
using WebUI.Models.NetworkDonator;
using WebUI.Models.Reports;
using WebUI.ViewModel;
using static WebUI.Models.Reports.reportviewmodel;

namespace WebUI.Pages.DonationReport
{
    [Authorize(Roles = SystemRoles.ViewReports + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly IPaymentClient _donationReport;
        private readonly IAppSettingService _appSettingService;
        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }

        [BindProperty]
        public ReportDonatorsearch Filters { get; set; }
        [BindProperty]
        public GetDonationQueryResult DonationReport { get; set; }
        public DonatorReportDto DonatorReportDto { get; set; }
        public IndexModel(IPaymentClient donationReport, IAppSettingService appSettingService)
        {
            _donationReport = donationReport;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            PageNumber = p == 0 ? 1 : p;

            var result = (await _donationReport.AllDonationsAsync(p == 0 ? 1 : p, null, null, null, null));


            PageNumber = p == 0 ? 1 : p;

            DonatorReportDto = new DonatorReportDto()
            {
                PageNumber = PageNumber,
                PageSize = 10,
                ProductsRequest = result.Donations.ToList(),
                TotalCount = result.TotalCount
            };
            TempData["DonationReportData"] = "";


        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            var result = (await _donationReport.AllDonationsAsync(p == 0 ? 1 : p, null, Filters?.Name?.Trim(), Filters?.phone?.Trim(),Filters?.Email));

            DonatorReportDto = new DonatorReportDto()
            {
                PageNumber = p == 0 ? 1 : p,
                PageSize = 10,
                ProductsRequest = result.Donations.ToList(),
                TotalCount = result.TotalCount
            };
            if (Filters.Name != null || Filters.phone != null || Filters.Email != null)
                TempData["DonationReportData"] = JsonConvert.SerializeObject(DonatorReportDto);
            else TempData["DonationReportData"] = null;
            TempData.Keep("DonationReportData");
            return Partial("DonationReportList", DonatorReportDto);
        }



        public async Task<IActionResult> OnGetExcelDownload()
        {
            DonatorReportDto details = JsonConvert.DeserializeObject<DonatorReportDto>((string)TempData["DonationReportData"] ?? "{}") ?? new DonatorReportDto();
            TempData.Keep("DonationReportData");
            if (details.ProductsRequest == null)
            {
                var resultAll = (await _donationReport.AllDonationsAsync(1, int.MaxValue, Filters?.Name?.Trim(), Filters?.phone?.Trim(),Filters?.Email));
                details.ProductsRequest = resultAll.Donations.ToList();
            }

            int Count = 1;

            var result = details.ProductsRequest.Select(a => new DonatorReportDTO
            {
                Serial = Count++,
                DonatorName = a.DonatorName,
                Email = a.Email,
                MobileNumber = a.MobileNumber,
                TotalAmount = a.TotalAmount,
                TotalCount = a.TotalCount,

            }).ToList();
            return new ExcelResult<DonatorReportDTO>(result, "Sheet1", "DonatorReport");
        }


    }
}
