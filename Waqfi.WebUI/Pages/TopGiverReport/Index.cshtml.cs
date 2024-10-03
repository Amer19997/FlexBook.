using System.Drawing.Printing;
using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Filters;
using WebUI.IntegrationServices;
using WebUI.Models.Reports;
using WebUI.Models.TopGivers;
using WebUI.ViewModel;

namespace WebUI.Pages.TopGiverReport
{
    [Authorize(Roles = SystemRoles.ViewReports + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly IReportsClient _reportsClient;
        public readonly ILookUpClient _lookUpClient;
        public IMapper _mapper;

        [BindProperty]
        public int? PageSize { get; set; }
        [BindProperty]
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }

        public GetTopGiversReportsQueryResult TopGiversDTO { get; set; }


        [BindProperty]
        public TopGiversReportFilter Filters { get; set; }
        public IndexModel(IReportsClient reportsClient, ILookUpClient lookUpClient, IMapper mapper)
        {
            _reportsClient = reportsClient;
            _lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGet(int p)
        {
            PageNumber = p == 0 ? 1 : p;


            TopGiversDTO = (await _reportsClient.GetAllTopGiversReportAsync(new GetTopGiversReportsQuery() { PageNumber = p == 0 ? 1 : p, PageSize = PageSize })).Result;


            TempData["Filter"] = JsonConvert.SerializeObject(new GetTopGiversReportsQuery() { PageNumber = p == 0 ? 1 : p });
            TempData.Keep("Filter");
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {

            var query = _mapper.Map<GetTopGiversReportsQuery>(Filters);

            query.PageNumber = PageNumber = (p == 0) ? 1 : p ?? 0;
            query.PageSize = PageSize ?? 10;


            TopGiversDTO = (await _reportsClient.GetAllTopGiversReportAsync(query)).Result;


            TempData["Filter"] = JsonConvert.SerializeObject(query);
            TempData.Keep("Filter");

            return Partial("_TopGiversReportList", TopGiversDTO);
        }


        public async Task<IActionResult> OnGetExportExcel()
        {
            GetTopGiversReportsQuery details = JsonConvert.DeserializeObject<GetTopGiversReportsQuery>((string)TempData["Filter"] ?? "{}") ?? new GetTopGiversReportsQuery();
            TempData.Keep("Filter");
            details.PageSize = int.MaxValue;

            TopGiversDTO = (await _reportsClient.GetAllTopGiversReportAsync(details)).Result;


            int Count = 1;

            var result = TopGiversDTO.TopGiversList.Select(a => new TopDonationsReport
            {
                Serial = Count++,
                TopDonatorName = a.TopDonatorName,
                Email = a.Email,
                MobileNumber = a.MobileNumber,
                ProductName = a.PrductName,
                DonationAmount = a.DonationAmount,
                DonationDate = a.DonationDate,
                MasaratName = a.MasarName,
                ProviderName = a.PrductName,
                 ProductNumber=a.ProductNumber

            }).ToList();

            string formattedDateTime = DateTime.Now.ToString("dd MMMM yyyy");
            string reportName = "Top Givers Report";
            string finalName = formattedDateTime + " " + reportName;

            return new ExcelResult<TopDonationsReport>(result, "Sheet1", finalName);
        }

        //public async Task<IActionResult> OnGetExcelDownload()
        //{
        //    GetProductsReportResultPaginatedList details = JsonConvert.DeserializeObject<GetProductsReportResultPaginatedList>((string)TempData["DonationReportData"] ?? "{}") ?? new GetProductsReportResultPaginatedList();
        //    TempData.Keep("DonationReportData");
        //    if (details.Items == null)
        //    {
        //        var resultAll = (await _reportClient.GetProductsReportAsync(Filters?.GehaName, Filters?.Contains, Filters?.MasarID, Filters?.UnitTypeID, Filters?.ProductType, Filters?.ProductSize, Filters?.ProductStatus, Filters?.DateFrom, Filters?.DateTo, Filters?.VerfiedDateFrom, Filters?.VerfiedDateTo, Filters?.RegestrationDateFrom, Filters?.RegestrationDateTo, 1, int.MaxValue)).Result;

        //        details.Items = resultAll.Items.ToList();
        //    }

        //    int Count = 1;

        //    var result = details.Items.Select(a => new ProductsReport
        //    {
        //        Serial = Count++,
        //        ProductName = a.ProductName,
        //        ProviderName = a.ProviderName,
        //        IBan = a.IBan,
        //        TotalAmountOfProduct = a.TotalAmountOfProduct,
        //        RemainingAmount = a.RemainingAmount,
        //        TotalOnline = a.TotalOnline,
        //        OfflineTotal = a.OfflineTotal,
        //        TopGiversTotal = a.TopGiversTotal,
        //        TotalDonationManasa = a.TotalDonationManasa,
        //        TotalCollectedAmount = a.TotalCollectedAmount
        //    }).ToList();
        //    DateTime dateTime = DateTime.Now;

        //    string formattedDateTime = dateTime.ToString("dd MMMM yyyy");
        //    string reportName = "Products Report";
        //    string finalName = formattedDateTime + " " + reportName;
        //    return new ExcelResult<ProductsReport>(result, "Sheet1", finalName);
        //}
    }
}
