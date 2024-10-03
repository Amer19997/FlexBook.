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
using WebUI.Models.Reports;
using WebUI.Models.TopGivers;
using static WebUI.Models.Reports.reportviewmodel;

namespace WebUI.Pages.OfflineDonationReport
{
    [Authorize(Roles = SystemRoles.ViewReports + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly IOfflineDonationClient _OfflineDonation;
        private readonly ILookUpClient _LookUp;
        private readonly IAppSettingService _appSettingService;
        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }
        [BindProperty]
        public ReportOfflineDonationSearch Filters { get; set; }
        public GetAllProviderNameQueryResultListTResponse Providers { get; set; }
        public ReportOfflineDonationDto ReportOfflineDonationDto { get; set; }
        public IndexModel(IAppSettingService appSettingService, IOfflineDonationClient offlinedonation, ILookUpClient lookup)
        {
            _appSettingService = appSettingService;
            _OfflineDonation = offlinedonation;
            _LookUp = lookup;
        }
        public async Task OnGetAsync(int p)
        {
            PageNumber = p == 0 ? 1 : p;

            var result = (await _OfflineDonation.GetOfflineDonationReportListAsync(null, null,null, null, null, p == 0 ? 1 : p, null, 0));

            PageNumber = p == 0 ? 1 : p;

            ReportOfflineDonationDto = new ReportOfflineDonationDto()
            {
                PageNumber = PageNumber,
                PageSize = 10,
                TotalCount = result.Result.TotalCount,
                OfflineDonationsList = result.Result.Items.ToList()
            };

            TempData["OfflineDonationReportData"] = "";
            TempData["SearchFilter"] = "";

        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<ReportOfflineDonationSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new ReportOfflineDonationSearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);

            var query = new ReportOfflineDonationSearch
            {
                DateFrom = Filters.DateFrom,
                DateTo = Filters.DateTo,
                ProductName = Filters.ProductName,
                ProviderName = Filters.ProviderName,
                IsParallelProduct = Filters.IsParallelProduct,
                ProductNumber= Filters.ProductNumber,
            };

            var result = (await _OfflineDonation.GetOfflineDonationReportListAsync(query?.ProviderName?.Trim(),
                                                                                  query?.ProductName?.Trim(),
                                                                                  query?.ProductNumber,
                                                                                  query?.DateFrom?.Split(' ')[0].Trim(),
                                                                                  query?.DateTo?.Split(' ')[0].Trim(),
                                                                                  p == 0 ? 1 : p,
                                                                                  null,
                                                                                  query.IsParallelProduct));

            ReportOfflineDonationDto = new ReportOfflineDonationDto()
            {
                PageNumber = p == 0 ? 1 : p,
                PageSize = 10,
                TotalCount = result.Result.TotalCount,
                OfflineDonationsList = result.Result.Items.ToList(),

            };

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            TempData.Keep("SearchFilter");



            ////if (Filters.ProviderName != null || Filters.ProductName != null || Filters.DateFrom != null || Filters.DateTo != null || Filters.IsParallelProduct != 0)
            ////    TempData["OfflineDonationReportData"] = JsonConvert.SerializeObject(ReportOfflineDonationDto);

            //else TempData["OfflineDonationReportData"] = null;

            //TempData.Keep("OfflineDonationReportData");

            return Partial("OfflineDonationList", ReportOfflineDonationDto);
        }

        public async Task<IActionResult> OnGetExcelDownload()
        {
            Filters = JsonConvert.DeserializeObject<ReportOfflineDonationSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new ReportOfflineDonationSearch();
            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);

            //ReportOfflineDonationDto details = JsonConvert.DeserializeObject<ReportOfflineDonationDto>((string)TempData["OfflineDonationReportData"] ?? "{}") ?? new ReportOfflineDonationDto();

            //TempData.Keep("OfflineDonationReportData");

            var resultAll = (await _OfflineDonation.GetOfflineDonationReportListAsync(Filters?.ProviderName?.Trim(),
                                                                                      Filters?.ProductName?.Trim(),
                                                                                      Filters?.ProductNumber,
                                                                                      Filters?.DateFrom,
                                                                                      Filters?.DateTo,
                                                                                      1,
                                                                                      int.MaxValue,
                                                                                       Filters?.IsParallelProduct));

          //  details.OfflineDonationsList = resultAll.Result.Items.ToList();

            int Count = 1;

            var result = resultAll.Result.Items.Select(a => new OfflineDonationReportExcelDto
            {
                Serial = Count++,
                ProductName = a.ProductNameAr,
                ProviderName = a.ProviderNameAr,
                Amount = a.Amount,
                ProductApprovalDate = a.ProductApprovalDate,
                IsParallelProduct = (a.IsParallelProduct == true ? "نعم" : "لا"),
                 ProductNumber=a.ProductNumber
            }).ToList();

            string formattedDateTime = DateTime.Now.ToString("dd MMMM yyyy");
            string reportName = "Offline Donation Report";
            string finalName = formattedDateTime + " " + reportName;

            return new ExcelResult<OfflineDonationReportExcelDto>(result, "Sheet1", finalName);
        }
    }
}
