using System.Globalization;
using AutoMapper;
using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Filters;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Donator;
using WebUI.Models.News;
using WebUI.Models.Reports;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebUI.Pages.ProductsReportUI
{
    [Authorize(Roles = SystemRoles.ViewReports + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        public IMapper _mapper;

        private readonly ILookUpClient _lookUpClient;
        private readonly IReportClient _reportClient;
        private readonly IAppSettingService _appSettingService;
        [BindProperty]
        public int PageSize { get; set; }
        [BindProperty]
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }

        [BindProperty]
        public ProductsReportSearch searchModel { get; set; }
        [BindProperty]
        public ProductReportSearchModel Filters { get; set; }
        [BindProperty]
        public GetProductsReportResultPaginatedList ItemList { get; set; }


        public IndexModel(ILookUpClient lookUpClient, IReportClient reportClient, IMapper mapper)
        {
            _lookUpClient = lookUpClient;
            _reportClient = reportClient;
            _mapper = mapper;

        }

        public async Task OnGet(int p)
        {

            ItemList = (await _reportClient.GetProductsReportAsync(new GetProductsReportQuery() { PageNumber= p == 0 ? 1 : p, PageSize= null })).Result;

            searchModel = new ProductsReportSearch()
            {
                DonationMethodList = (await _lookUpClient.GetDonationMethodAsync()).Result.ToList(),
                GetMasaratListResult = (await _lookUpClient.GetMasaratListAsync(int.MaxValue, 1)).Result.MasaratItemDtos.ToList(),
                GetProductSizeList = (await _lookUpClient.GetProductSizeAsync()).Result.ToList(),
                GetProductPaymentStatus = (await _lookUpClient.GetProductPaymentStatusAsync()).Result.ProductPaymentList.ToList(),
                UnitTypies = (await _lookUpClient.GetProductTypeListAsync()).Result.ToList(),

            };
            PageNumber = p == 0 ? 1 : p;
            TotalCount = ItemList.TotalCount;
            //TempData["DonationReportData"] = "";
            TempData["SearchFilter"] = "";
        }

        public async Task OnGetFilter(int p)
        {


            ItemList = (await _reportClient.GetProductsReportAsync(new GetProductsReportQuery() { PageNumber = p == 0 ? 1 : p, PageSize = null })).Result;

            searchModel = new ProductsReportSearch()
            {
                DonationMethodList = (await _lookUpClient.GetDonationMethodAsync()).Result.ToList(),
                GetMasaratListResult = (await _lookUpClient.GetMasaratListAsync(int.MaxValue, 1)).Result.MasaratItemDtos.ToList(),
                GetProductSizeList = (await _lookUpClient.GetProductSizeAsync()).Result.ToList(),
                GetProductPaymentStatus = (await _lookUpClient.GetProductPaymentStatusAsync()).Result.ProductPaymentList.ToList(),
                UnitTypies = (await _lookUpClient.GetProductTypeListAsync()).Result.ToList(),

            };
            PageNumber = p == 0 ? 1 : p;
            TotalCount = ItemList.TotalCount;
            //TempData["DonationReportData"] = "";
            TempData["SearchFilter"] = "";
        }


        [HttpPost]
        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<ProductReportSearchModel>((string)TempData["SearchFilter"] ?? "{}") ?? new ProductReportSearchModel();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            var query = new GetProductsReportQuery
            {
                 GehaName= Filters.GehaName,
                 MasarId = Filters.MasarId,
                 PageNumber = Filters.PageNumber,
                 Contain= Filters.Contain,
                 PeriodFrom= Filters.PeriodFrom,
                 PeriodTo= Filters.PeriodTo,
                 ProductPaymentStatus= Filters.ProductPaymentStatus,
                 ProductSize= Filters.ProductSize,
                 PageSize= Filters.PageSize,
                 RegestrationDateFrom= Filters.RegestrationDateFrom,
                 RegestrationDateTo= Filters.RegestrationDateTo,
                 ProductType= Filters.ProductType,
                UnitType = Filters.UnitType,
                 VerfiedDateFrom= Filters.VerfiedDateFrom,
                 VerfiedDateTo= Filters.VerfiedDateTo,
                 ParallelProduct=Filters.ParallelProduct,
                 ProductNumber=Filters.ProductNumber,   
            };
            query.PageNumber = PageNumber = (p == 0) ? 1 : p ?? 0;

            var result = (await _reportClient.GetProductsReportAsync(query)).Result;

           

            //if (Filters.GehaName != null || Filters.MasarId != null || Filters.UnitType != null || Filters.ProductType != null || Filters.ProductSize != null || Filters.Contain != null || Filters.ProductPaymentStatus != null || Filters.PeriodFrom != null || Filters.PeriodTo != null || Filters.VerfiedDateFrom != null || Filters.VerfiedDateTo != null || Filters.RegestrationDateFrom != null || Filters.RegestrationDateTo != null)
            //    TempData["DonationReportData"] = JsonConvert.SerializeObject(result);
            //else TempData["DonationReportData"] = null;
            //TempData.Keep("DonationReportData");

            TotalCount = result.TotalCount;
            PageNumber = p == 0 ? 1 : p.Value;
            PageSize= 10;
            TempData.Keep("SearchFilter");

            return Partial("_List", result);
        }
        public async Task<IActionResult> OnGetExcelDownload()
        {
            Filters = JsonConvert.DeserializeObject<ProductReportSearchModel>((string)TempData["SearchFilter"] ?? "{}") ?? new ProductReportSearchModel();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            var query = new GetProductsReportQuery
            {
                GehaName = Filters.GehaName,
                MasarId = Filters.MasarId,
                PageNumber = Filters.PageNumber,
                Contain = Filters.Contain,
                PeriodFrom = Filters.PeriodFrom,
                PeriodTo = Filters.PeriodTo,
                ProductPaymentStatus = Filters.ProductPaymentStatus,
                ProductSize = Filters.ProductSize,
                PageSize = Filters.PageSize,
                RegestrationDateFrom = Filters.RegestrationDateFrom,
                RegestrationDateTo = Filters.RegestrationDateTo,
                ProductType = Filters.ProductType,
                UnitType = Filters.UnitType,
                VerfiedDateFrom = Filters.VerfiedDateFrom,
                VerfiedDateTo = Filters.VerfiedDateTo,
                ParallelProduct= Filters.ParallelProduct
            };
            query.PageNumber = 1;
            query.PageSize = int.MaxValue;

            GetProductsReportResultPaginatedList details =  new GetProductsReportResultPaginatedList();

          
                var resultAll = (await _reportClient.GetProductsReportAsync(query)).Result;

                details.Items = resultAll.Items.ToList();
            

            int Count = 1;

            var result = details.Items.Select(a => new ProductsReport
            {
                Serial = Count++,
                ProductName = a.ProductName,
                ProviderName = a.ProviderName,
                IBan = a.IBan,
                TotalAmountOfProduct = a.TotalAmountOfProduct,
                RemainingAmount = a.RemainingAmount,
                TotalOnline = a.TotalOnline,
                OfflineTotal = a.OfflineTotal,
                TopGiversTotal = a.TopGiversTotal,
                TotalDonationManasa = a.TotalDonationManasa,
                TotalCollectedAmount = a.TotalCollectedAmount,
                MeritTotal=a.MeritTotal,
                IsParallelProduct= a.IsParallelProduct ? "نعم" : "لا",
                ProductNumber=a.ProductNumber
            }).ToList();
            DateTime dateTime = DateTime.Now;
            TempData.Keep("SearchFilter");

            string formattedDateTime = dateTime.ToString("dd MMMM yyyy");
            string reportName = "Products Report";
            string finalName = formattedDateTime + " " + reportName;
            return new ExcelResult<ProductsReport>(result, "Sheet1", finalName);
        }

        
    }
}
