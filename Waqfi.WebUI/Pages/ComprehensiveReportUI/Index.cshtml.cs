using System.Globalization;
using AutoMapper;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Donator;
using WebUI.Models.News;
using WebUI.Models.Reports;

namespace WebUI.Pages.ComprehensiveReportUI
{
    [Authorize(Roles = SystemRoles.ViewReports + " , " + SystemRoles.SuperAdmin)]
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookUpClient;
        private readonly IReportClient _reportClient;
        private readonly IAppSettingService _appSettingService;
        public IMapper _mapper;
        [BindProperty]
        public int PageSize { get; set; }
        [BindProperty]
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }

        [BindProperty]
        public ComprehensiveSearch searchList { get; set; }
        [BindProperty]
        public ComprehensiveReportQueryResult ItemList { get; set; }
        [BindProperty]
        public ComprehensiveReportSearch ComprehensiveReportSearch { get; set; }


        public IndexModel(ILookUpClient lookUpClient, IReportClient reportClient, IMapper mapper)
        {
            _lookUpClient = lookUpClient;
            _reportClient = reportClient;
            _mapper = mapper;
        }

        public async Task OnGet(int p,int pageSize =15)
        {
            PageSize = pageSize;
            PageNumber = 1;
           
            ComprehensiveReportSearch = new ComprehensiveReportSearch() { };
            TempData["SearchFilter"] = JsonConvert.SerializeObject(ComprehensiveReportSearch);
            ItemList = (await _reportClient.GetComprehensiveReportAsync(new ComprehensiveReportQuery() { PageNumber= p == 0 ? 1 : p, PageSize= PageSize })).Result;

            searchList = new ComprehensiveSearch()
            {
                DonationMethodList = (await _lookUpClient.GetDonationMethodAsync()).Result.ToList(),
                GetMasaratListResult = (await _lookUpClient.GetMasaratListAsync(int.MaxValue, 1)).Result.MasaratItemDtos.ToList(),
                GetProductSizeList = (await _lookUpClient.GetProductSizeAsync()).Result.ToList(),
                GetProductPaymentStatus = (await _lookUpClient.GetProductPaymentStatusAsync()).Result.ProductPaymentList.ToList(),
                UnitTypies=   (await _lookUpClient.GetReportProductTypesListAsync()).Result.ToList(),

            };

            TempData["Filter"] = JsonConvert.SerializeObject(new ComprehensiveReportQuery() { PageNumber = p == 0 ? 1 : p });
            TempData.Keep("Filter");
            TempData["PageSize"] = PageSize;
            TempData.Keep("PageSize");

        }
        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {

            if (p != 0)
                ComprehensiveReportSearch = JsonConvert.DeserializeObject<ComprehensiveReportSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new ComprehensiveReportSearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(ComprehensiveReportSearch);

            var query = _mapper.Map<ComprehensiveReportQuery>(ComprehensiveReportSearch);

            query.PageNumber = PageNumber = (p == 0) ? 1 : p ?? 0;

            query.PageSize =(int)TempData["PageSize"];
            TempData["PageSize"] = query.PageSize;
            TempData.Keep("PageSize");
            ItemList = (await _reportClient.GetComprehensiveReportAsync(query)).Result;

            searchList = new ComprehensiveSearch()
            {
                DonationMethodList = (await _lookUpClient.GetDonationMethodAsync()).Result.ToList(),
                GetMasaratListResult = (await _lookUpClient.GetMasaratListAsync(int.MaxValue, 1)).Result.MasaratItemDtos.ToList(),
                GetProductSizeList = (await _lookUpClient.GetProductSizeAsync()).Result.ToList(),
                GetProductPaymentStatus = (await _lookUpClient.GetProductPaymentStatusAsync()).Result.ProductPaymentList.ToList(),
                UnitTypies = (await _lookUpClient.GetReportProductTypesListAsync()).Result.ToList(),

            };

            
             TempData["Filter"]= JsonConvert.SerializeObject(query);
             TempData.Keep("Filter");
            

            return Partial("_List", ItemList);
        }
        public async Task<IActionResult> OnGetExcelDownload()
        {
            ComprehensiveReportQuery details = JsonConvert.DeserializeObject<ComprehensiveReportQuery>((string)TempData["Filter"] ?? "{}") ?? new ComprehensiveReportQuery();
            TempData.Keep("Filter");
            details.PageSize = int.MaxValue;
            ItemList = (await _reportClient.GetComprehensiveReportAsync(details)).Result;

         

            var result = ItemList.ComprehensiveReportList.Select(a => new ComprehensiveReportExcelSheet
            {
                
                Average= a.Average,
                BankIBAN= a.BankIBAN,
                BankName= a.BankName,
                Converted   = a.Converted,
                DeservedAmount= a.DeservedAmount.Value.ToString("C2", new CultureInfo("en-SA")).Replace("SAR", string.Empty),
                ProdcutName= a.ProdcutName,
                ProductAmount= a.ProductAmount.Value.ToString("C2", new CultureInfo("en-SA")).Replace("SAR", string.Empty),
                ProviderName = a.ProviderName,
                Remaining = a.Remaining.Value.ToString("C2", new CultureInfo("en-SA")).Replace("SAR", string.Empty),
                TotalOnlinePaid= a.TotalOnlinePaid.Value.ToString("C2", new CultureInfo("en-SA")).Replace("SAR", string.Empty),
                TotalPaid= a.TotalPaid.Value.ToString("C2", new CultureInfo("en-SA")).Replace("SAR", string.Empty),
                IsParallelProduct=a.IsParallelProduct==true ? "نعم" :"لا",
                ProductNumber=a.ProductNumber
            }).ToList();
            
            //var excelName = "ComprehensiveReport " + DateTime.Now.Date.ToString("dd MMM yyyy", CultureInfo.CreateSpecificCulture("AR-AR")) ?? string.Empty;
            
            var excelName = "ComprehensiveReport " + DateTime.Now.Date.ToString("dd MMM yyyy");

            return new ExcelResult<ComprehensiveReportExcelSheet>(result, "Sheet1", excelName);
            
        }
    }
}
