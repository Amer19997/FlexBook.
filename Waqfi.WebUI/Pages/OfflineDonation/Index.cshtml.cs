using DocumentFormat.OpenXml.Drawing;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Filters;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Banner;
using WebUI.Models.OfflineDonation;

namespace WebUI.Pages.OfflineDonation
{
    [Authorize(Roles = SystemRoles.OfflineDonationRequests + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly IAppSettingService _appSettingService;
        private readonly IOfflineDonationClient _offlineDonationClient;
        public readonly ILookUpClient _lookUpClient;
        public string Error { get; set; }
        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }
        public OfflineDonationsDto OfflineDonationRequests { get; set; }
        public GetOfflineProviderDonatorLookUpQueryResult LookupProv { get; set; }
        public GetOfflineProductDonatorsLookupQueryResult LookupProd { get; set; }
        public GetOfflineStatusDonatorLookUpsQueryResult LookupStatus { get; set; }
        [BindProperty]
        public OfflineDonationFilterDto Filters { get; set; }
        public IndexModel(IAppSettingService appSettingService, IOfflineDonationClient offlineDonationClient, ILookUpClient lookUpClient)
        {
            _appSettingService = appSettingService;
            PageSize = appSettingService.Pager_PageSize;
            _offlineDonationClient = offlineDonationClient;
            _lookUpClient = lookUpClient;
        }

        public async Task OnGet(int p, string error)
        {

            var ProviderLookups = await _lookUpClient.GetOfflineProviderDonatorsLookupsAsync();
            if (ProviderLookups.Success)
                LookupProv = ProviderLookups.Result;

            var ProductLookups = await _lookUpClient.GetOfflineProductDonatorsLookupsAsync();
            if (ProductLookups.Success)
                LookupProd = ProductLookups.Result;

            var StatusLookups = await _lookUpClient.GetOfflineStatusDonatorLookUpsAsync();
            if (StatusLookups.Success)
                LookupStatus = StatusLookups.Result;

            PageNumber = p == 0 ? 1 : p;


            var result = await _offlineDonationClient.GetOfflineDonationListAsync(null, null, null, _appSettingService.Pager_PageSize, PageNumber);

            OfflineDonationRequests = new OfflineDonationsDto()
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                TotalCount = result.Result.TotalCount,
                OfflineDonationRequests = result.Result.Items.ToList(),
            };

            TempData["SearchFilter"] = null;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<OfflineDonationFilterDto>((string)TempData["SearchFilter"] ?? "{}") ?? new OfflineDonationFilterDto();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);

            PageNumber = p == 0 ? 1 : p;

            var result = await _offlineDonationClient.GetOfflineDonationListAsync(Filters.Providers,Filters.Products,Filters.Status,_appSettingService.Pager_PageSize, PageNumber);;

            var ResDto = new OfflineDonationsDto()
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                OfflineDonationRequests = result.Result.Items.ToList(),
                TotalCount = result.Result.TotalCount
            };

            return Partial("_OfflineDonnerList", ResDto);
        }

        [HttpGet]
        public async Task<IActionResult> OnGetApproveRequest(string RequestId)
        {

            var Res = await _offlineDonationClient.ApproveOfflineDonationAsync(new ApproveOfflineDonationCommand
            {
                OfflineDonationId= Guid.Parse(RequestId)
            });

            return new OkObjectResult(Res);

        }


        [HttpPost]
        public async Task<IActionResult> OnPostRejectRequest(string RequestId, string RejectReson)
        {

            var Res = await _offlineDonationClient.RejectOfflineDonationAsync(new RejectOfflineDonationCommand
            {
                Note= RejectReson.Trim(),
                OfflineDonationId=Guid.Parse(RequestId)
            });

            return new OkObjectResult(Res);

        }
        [HttpGet]
        public async Task<IActionResult> OnGetDownloadFile(string requiestId)
        {
             var file = await _offlineDonationClient.DownloadDonationDocumentForCmsAsync(Guid.Parse(requiestId));
             return new OkObjectResult(file);
        }


    }
}
