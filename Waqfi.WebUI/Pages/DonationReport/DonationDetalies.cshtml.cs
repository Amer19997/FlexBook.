using DocumentFormat.OpenXml.EMMA;
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
using WebUI.Models.Provider;
using WebUI.Models.Reports;
using static WebUI.Models.Reports.reportviewmodel;

namespace WebUI.Pages.DonationReport
{
    [Authorize(Roles = SystemRoles.ViewReports + " , " + SystemRoles.SuperAdmin)]
    public class DonationDetaliesModel : PageModel
    {
        private readonly IPaymentClient _paymentClient;

        private readonly IAppSettingService _appSettingService;

        [BindProperty]
        public ReportDonatorDetaliessearch Filters { get; set; }

        public string DonatorName { get; set; }
        public int? PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string Error { get; set; }
        public Guid? PersonId { get; set; }
        public reportList ReportList { get; set; }

        [BindProperty]
        public GetDonationDetailsQueryResultTResponse NewsViewModals { get; set; }
        public DonationDetaliesModel(IPaymentClient paymentClient, IAppSettingService appSettingService)
        {
            this._paymentClient = paymentClient;
            _appSettingService = appSettingService;
            ReportList = new reportList();
        }

        public async Task OnGet(Guid PersonsId, int p)
        {
            await Getreposts(PersonsId,p);
            TempData["DonationDetailsData"] = "";
            PersonId = PersonsId;
            TempData["SearchFilter"] = JsonConvert.SerializeObject(new ReportDonatorDetaliessearch { PersonId = PersonId});
        }
        private async Task<reportList> Getreposts(Guid? personId,int? p = 0)
        {
            TempData.Keep("DonationDetailsData");
            PageNumber = p == 0 ? 1 : p;
            var result = await _paymentClient.PersonDonationAsync(p == 0 ? 1 : p,null, personId ?? Filters?.PersonId, Filters?.DataFrom,Filters?.DataTo);
            DonatorName = result.Result.DonatorName;
            ReportList = new reportList
            {
                reportViewModals = result.Result.Donations.Select(d => new reportviewmodel
                {
                     Amount= d.Amount,
                     DonationDate= d.DonationDate,
                     Masar=d.Masar,
                     ProductName=d.ProductName,
                     ProviderName = d.ProviderName,
                     DonatorName=result.Result.DonatorName,
                     ProductNumber   =d.ProductNumber
                }).ToList(),
                TotalCount = result.Result.TotalCount,
                PageNumber = PageNumber,
                PageSize = _appSettingService.Pager_PageSize,
            };

            return ReportList;

        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<ReportDonatorDetaliessearch>((string)TempData["SearchFilter"] ?? "{}") ?? new ReportDonatorDetaliessearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            await Getreposts(null,p);
            TempData.Keep("SearchFilter");

            //if (Filters.DataFrom != null || Filters.DataTo != null)
            //    TempData["DonationDetailsData"] = JsonConvert.SerializeObject(ReportList);
            //else TempData["DonationDetailsData"] = null;

            //TempData.Keep("DonationDetailsData");
            
            return Partial("_detaliesList", ReportList);
        }

        public async Task<IActionResult> OnGetExcelDownload(Guid personId)
        {
            Filters = JsonConvert.DeserializeObject<ReportDonatorDetaliessearch>((string)TempData["SearchFilter"] ?? "{}") ?? new ReportDonatorDetaliessearch();
            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            TempData.Keep("SearchFilter");


            //reportList details = JsonConvert.DeserializeObject<reportList>((string)TempData["DonationDetailsData"] ?? "{}") ?? new reportList();
            //if (details.reportViewModals.Count==0&&details.PageSize==null)
            //{
            var DetailsResult = await _paymentClient.PersonDonationAsync(1, int.MaxValue,personId, Filters.DataFrom, Filters.DataTo);
                ReportList = new reportList
                {
                    reportViewModals = DetailsResult.Result.Donations.Select(d => new reportviewmodel
                    {
                        Amount = d.Amount,
                        DonationDate = d.DonationDate,
                        Masar = d.Masar,
                        ProductName = d.ProductName,
                        ProviderName = d.ProviderName,
                        DonatorName = DetailsResult.Result.DonatorName,
                         ProductNumber= d.ProductNumber,
                         
                    }).ToList(),
                    TotalCount = DetailsResult.Result.TotalCount,
                    PageNumber = PageNumber,
                    PageSize = _appSettingService.Pager_PageSize,
                };
           // }
            int Count = 1;

            var result = ReportList.reportViewModals.Select(a => new DonatorDetailsReport
            {
                Serial = Count++,
                ProductName = a.ProductName,
                ProviderName = a.ProviderName,
                Masar = a.Masar,
                Amount = a.Amount,
                DonationDate = a.DonationDate,
                ProductNumber=a.ProductNumber
            }).ToList();

            string DonatorName = DetailsResult.Result.DonatorName;
            string reportName = "Donator Donations";
            string finalName = DonatorName + " " + reportName;

            return new ExcelResult<DonatorDetailsReport>(result, "Sheet1", finalName);
        }

    }
}
