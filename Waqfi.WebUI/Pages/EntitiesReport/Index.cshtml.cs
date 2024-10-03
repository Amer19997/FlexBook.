using System.Globalization;
using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Reports;

namespace WebUI.Pages.EntitiesReport
{
    [Authorize(Roles = SystemRoles.ViewReports + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookUpClient;
        private readonly IProviderClient _providerClient;
        private readonly IReportClient _reportClient;
        private readonly IAppSettingService _appSettingService;
        public List<Int32LookupDto> ProviderTypes { get; set; }

        [BindProperty]
        public EntitiesReportSearch Filters { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }

        [BindProperty]
        public EntitiesReportSearch search { get; set; }


        [BindProperty]
        public EntitiesReportItemPaginatedListTResponse ItemList { get; set; }
        public IndexModel(IReportClient reportClient, IProviderClient providerClient)
        {
            _reportClient = reportClient;
            _providerClient = providerClient;
        }
        public async Task OnGet(int p, int pageSize = 15)
        {
            ItemList = (await _reportClient.GetEntitiesReportAsync(new EntitiesReportQuery() { PageNumber = p == 0 ? 1 : p, PageSize = pageSize }));


            search = new EntitiesReportSearch()
            {
                GetDonationMethodQueryResult = (await _providerClient.GetProviderTypesAsync()).Result.ToList()

            };
            TempData["SearchFilter"] = "";
            TempData["PageSize"] = pageSize;
            TempData.Keep("PageSize");
            PageSize = pageSize;
        }

        [HttpPost]
        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<EntitiesReportSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new EntitiesReportSearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            var query = new EntitiesReportQuery
            {
                Contains = Filters.Contains,
                PaymentStatusWithin = Filters.PaymentStatusWithin,
                ProviderType = Filters.ProviderType,
                RegestrationEndDateFrom = Filters.RegestrationEndDateFrom,
                PeriodFrom = Filters.PeriodFrom,
                PeriodTo = Filters.PeriodTo,
                RegestrationEndDateTo = Filters.RegestrationEndDateTo,
                RegestrationDateFrom = Filters.RegestrationDateFrom,
                RegestrationDateTo = Filters.RegestrationDateTo,
                VerfiedDateFrom = Filters.VerfiedDateFrom,
                VerfiedDateTo = Filters.VerfiedDateTo,
                PageSize = Filters.PageSize
            };
            query.PageNumber = PageNumber = (p == 0) ? 1 : p ?? 0;

            var result = (await _reportClient.GetEntitiesReportAsync(query)).Result;



            //if (Filters.GehaName != null || Filters.MasarId != null || Filters.UnitType != null || Filters.ProductType != null || Filters.ProductSize != null || Filters.Contain != null || Filters.ProductPaymentStatus != null || Filters.PeriodFrom != null || Filters.PeriodTo != null || Filters.VerfiedDateFrom != null || Filters.VerfiedDateTo != null || Filters.RegestrationDateFrom != null || Filters.RegestrationDateTo != null)
            //    TempData["DonationReportData"] = JsonConvert.SerializeObject(result);
            //else TempData["DonationReportData"] = null;
            //TempData.Keep("DonationReportData");

            TotalCount = result.TotalCount;
            PageNumber = p == 0 ? 1 : p.Value;
            query.PageSize = (int)TempData["PageSize"];

            TempData.Keep("PageSize");
            TempData.Keep("SearchFilter");

            return Partial("_List", result);
        }
        public async Task<IActionResult> OnGetExcelDownload()
        {
            Filters = JsonConvert.DeserializeObject<EntitiesReportSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new EntitiesReportSearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            var query = new EntitiesReportQuery
            {
                Contains = Filters.Contains,
                PaymentStatusWithin = Filters.PaymentStatusWithin,
                ProviderType = Filters.ProviderType,
                RegestrationEndDateFrom = Filters.RegestrationEndDateFrom,
                PeriodFrom = Filters.PeriodFrom,
                PeriodTo = Filters.PeriodTo,
                RegestrationEndDateTo = Filters.RegestrationEndDateTo,
                RegestrationDateFrom = Filters.RegestrationDateFrom,
                RegestrationDateTo = Filters.RegestrationDateTo,
                VerfiedDateFrom = Filters.VerfiedDateFrom,
                VerfiedDateTo = Filters.VerfiedDateTo,
                PageSize = Filters.PageSize
            };
            query.PageNumber = 1;
            query.PageSize = int.MaxValue;

            EntitiesReportItemPaginatedList details = new EntitiesReportItemPaginatedList();


            var resultAll = (await _reportClient.GetEntitiesReportAsync(query)).Result;

            details.Items = resultAll.Items.ToList();


            int Count = 1;

            var result = details.Items.Select(a => new EnitiesReportExport
            {
                Serial = Count++,
                ProviderName = a.ProviderName,
                TotalGatheredDonations = a.TotalGatheredDonations,
                RemainingAmount = a.RemainingAmount,
                TotalOnlineDonations = a.TotalOnlineDonations,
                IdentityNumber = a.IdentityNumber,
                TotalProductsAmount = a.TotalProductsAmount,
                TotalTopGiversAmount = a.TotalTopGiversAmount,
                meritAmount = a.MeritTotal,
                TransferdAmount=0,
                ProductNumber= a.Products.FirstOrDefault()?.ProductNumber,
                Products = a.Products.Select(_=> new Models.Reports.ProductDto
                {
                    ProductName = _.ProductName,
                    BankIban= _.BankIban,
                    BankName= _.BankName,
                    ProductType = _.ProductType
                }).ToList()
            }).ToList();
            DateTime dateTime = DateTime.Now;
            TempData.Keep("SearchFilter");

            string formattedDateTime = dateTime.ToString("dd MMMM yyyy");
            string reportName = "Gehat Report";
            string finalName = formattedDateTime + " " + reportName;
            return new ExcelResult<EnitiesReportExport>(result, "Sheet1", finalName);
        }

    }
}
