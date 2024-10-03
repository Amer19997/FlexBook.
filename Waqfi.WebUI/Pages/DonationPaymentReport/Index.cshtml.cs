using DocumentFormat.OpenXml.Wordprocessing;
using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Reports;

namespace WebUI.Pages.DonationPaymentReport
{
    [Authorize(Roles = SystemRoles.ViewReports + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookUpClient;

        private readonly IProviderClient _providerClient;
        private readonly IReportsClient _ReportsClient;
        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }
        [BindProperty]
        public DonationPaymentReportSearch Filters { get; set; }
        public DonationPaymentReportDto DonationPaymentReportDto { get; set; }
        [BindProperty]
        public List<GetPaymentMethodsQueryResult> PaymentMethod { get; set; }
        public List<GetPaymentStatusQueryResult> PaymentStatus { get; set; }

        public DonationPaymentReportQueryResultPaginatedList Result { get; set; }

        public IndexModel(ILookUpClient lookUpClient,IProviderClient providerClient, IReportsClient reportsClient)
        {
            _lookUpClient = lookUpClient;
            _providerClient = providerClient;
            _ReportsClient = reportsClient;
        }
        public async Task OnGetAsync(int p)
        {
            PaymentStatus = (await _lookUpClient.GetPaymentStatusAsync()).Result.ToList();
            PaymentMethod = (await _lookUpClient.GetPaymentMethodAsync()).Result.ToList();

            Result = (await _ReportsClient.GetDonationPaymentReportListAsync(null, null, null, null, 1, null)).Result;
            PageNumber = p == 0 ? 1 : p;
            TotalCount = Result.TotalCount;
            TempData["DonationReportData"] = "";
        }


        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<DonationPaymentReportSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new DonationPaymentReportSearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            TempData.Keep("SearchFilter");

            var result = (await _ReportsClient.GetDonationPaymentReportListAsync(Filters?.RequestStatus,Filters?.PaymentMethod,Filters?.DateFrom,Filters?.DateTo, p, null)).Result;

            
            //if (Filters.RequestStatus != null || Filters.PaymentMethod != null || Filters.DateTo != null || Filters.DateFrom != null)
            //    TempData["DonationReportData"] = JsonConvert.SerializeObject(result);


            //else TempData["DonationReportData"] = null;
            //TempData.Keep("DonationReportData");

            TotalCount = result.TotalCount;
            result.PageNumber = ( p == 0 ? 1 : p.Value);
            PageSize= result.PageSize;
            return Partial("DonationPaymentList", result);
        }

        public async Task<IActionResult> OnGetExcelDownload()
        {
            //DonationPaymentReportQueryResultPaginatedList details = JsonConvert.DeserializeObject<DonationPaymentReportQueryResultPaginatedList>((string)TempData["DonationReportData"] ?? "{}") ?? new DonationPaymentReportQueryResultPaginatedList();
            //TempData.Keep("DonationReportData");

            Filters = JsonConvert.DeserializeObject<DonationPaymentReportSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new DonationPaymentReportSearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);

            var resultFilter = (await _ReportsClient.GetDonationPaymentReportListAsync(Filters?.RequestStatus, Filters?.PaymentMethod, Filters?.DateFrom, Filters?.DateTo, 1, int.MaxValue)).Result;

            //if (details.Items == null)
            //{
            //    var resultAll = (await _ReportsClient.GetDonationPaymentReportListAsync(Filters?.RequestStatus, Filters?.PaymentMethod, Filters?.DateFrom, Filters?.DateTo, 1, int.MaxValue));

            //    details.Items = resultAll.Result.Items.ToList();
            //}

            int Count = 1;

            var result = resultFilter.Items.Select(a => new DonationPaymentReportDto
            {
                Serial = Count++,
                PaymentStatus = a.PaymentStatus,
                Amount = a.Amount,
                DateTimeDonation=a.DateTimeDonation,
                PaymentMethod=a.PaymentMethod,
                ProductProvider = a.ProductProvider,
                ProductNumber=a.ProductNumber
            }).ToList();
            DateTime dateTime = DateTime.Now;

            string formattedDateTime = dateTime.ToString("dd MMMM yyyy");
            string reportName = "Products Report";
            string finalName = formattedDateTime + " " + reportName;
            return new ExcelResult<DonationPaymentReportDto>(result, "Sheet1", finalName);
        }

        public async Task<IActionResult> OnGetPdfDownload(Guid paymentId)
        {
            Filters = JsonConvert.DeserializeObject<DonationPaymentReportSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new DonationPaymentReportSearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);

            var resultFilter = (await _ReportsClient.GetDonationPaymentReportListAsync(Filters?.RequestStatus, Filters?.PaymentMethod, Filters?.DateFrom, Filters?.DateTo, 1, int.MaxValue)).Result;

            //if (details.Items == null)
            //{
            //    var resultAll = (await _ReportsClient.GetDonationPaymentReportListAsync(Filters?.RequestStatus, Filters?.PaymentMethod, Filters?.DateFrom, Filters?.DateTo, 1, int.MaxValue));

            //    details.Items = resultAll.Result.Items.ToList();
            //}

            int Count = 1;

            var result = resultFilter.Items.Select(a => new DonationPaymentReportDto
            {
                Serial = Count++,
                PaymentStatus = a.PaymentStatus,
                Amount = a.Amount,
                DateTimeDonation = a.DateTimeDonation,
                PaymentMethod = a.PaymentMethod,
                ProductProvider = a.ProductProvider,
                ProductNumber = a.ProductNumber
            }).ToList();
            DateTime dateTime = DateTime.Now;

            string formattedDateTime = dateTime.ToString("dd MMMM yyyy");
            string reportName = "Products Report";
            string finalName = formattedDateTime + " " + reportName;
            return new ExcelResult<DonationPaymentReportDto>(result, "Sheet1", finalName);
        }

        public async Task<IActionResult> OnGetPaymentData(string donationPaymentNumber)
        {
            Filters = JsonConvert.DeserializeObject<DonationPaymentReportSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new DonationPaymentReportSearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);

            var resultFilter = (await _ReportsClient.GetDonationPaymentReportListAsync(Filters?.RequestStatus, Filters?.PaymentMethod, Filters?.DateFrom, Filters?.DateTo, 1, int.MaxValue)).Result;

            //if (details.Items == null)
            //{
            //    var resultAll = (await _ReportsClient.GetDonationPaymentReportListAsync(Filters?.RequestStatus, Filters?.PaymentMethod, Filters?.DateFrom, Filters?.DateTo, 1, int.MaxValue));

            //    details.Items = resultAll.Result.Items.ToList();
            //}

            int Count = 1;

            var result = resultFilter.Items.Select(a => new DonationPaymentReportDto
            {
                Serial = Count++,
                PaymentStatus = a.PaymentStatus,
                Amount = a.Amount,
                DateTimeDonation = a.DateTimeDonation,
                PaymentMethod = a.PaymentMethod,
                ProductProvider = a.ProductProvider,
                ProductNumber = a.ProductNumber
            }).ToList();
            DateTime dateTime = DateTime.Now;

            string formattedDateTime = dateTime.ToString("dd MMMM yyyy");
            string reportName = "Products Report";
            string finalName = formattedDateTime + " " + reportName;
            return new ExcelResult<DonationPaymentReportDto>(result, "Sheet1", finalName);
        }
    }
}
