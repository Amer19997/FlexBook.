using System.Drawing.Printing;
using System.Globalization;
using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.NetworkDonator;
using WebUI.Models.News;

namespace WebUI.Pages.NetworkDonator
{
    [Authorize(Roles = SystemRoles.NetworkDonationList + " , " + SystemRoles.SuperAdmin)]
    public class Index : PageModel
    {
        private readonly INetworkDonatorClient _networkDonator;
        private readonly IAppSettingService _appSettingService;

        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }

        public NetworkDonatorDTO networkDonatorDTO { get; set; }

        [BindProperty]
        public NetworkDonatorsearch Filters { get; set; }
        public GetAllNetworkDonatorResultPaginatedList networkDonators { get; set; }

        public Index(INetworkDonatorClient networkDonator, IAppSettingService appSettingService)
        {
            _networkDonator = networkDonator;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            var result = (await _networkDonator.GetAllNetworkDonatorAsync(null, null, _appSettingService.Pager_PageSize, p == 0 ? 1 : p));

            PageNumber = p == 0 ? 1 : p;

            networkDonatorDTO = new NetworkDonatorDTO()
            {
                PageNumber = PageNumber,
                PageSize = _appSettingService.Pager_PageSize,
                ProductsRequest = result.Result.Items.ToList(),
                TotalCount = result.Result.TotalCount
            };
            TempData["SearchFilter"] = null;
            TempData["NetworkDonationReportData"] = "";


        }
        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<NetworkDonatorsearch>((string)TempData["SearchFilter"] ?? "{}") ?? new NetworkDonatorsearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            var result = (await _networkDonator.GetAllNetworkDonatorAsync(Filters.Name?.Trim(), Filters.Email?.Trim(), _appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            PageNumber = p == 0 ? 1 : p;

            networkDonatorDTO = new NetworkDonatorDTO()
            {
                PageNumber = PageNumber,
                PageSize = _appSettingService.Pager_PageSize,
                ProductsRequest = result.Result.Items.ToList(),
                TotalCount = result.Result.TotalCount
            };
            if (Filters.Name != null || Filters.Email != null)
                TempData["NetworkDonationReportData"] = JsonConvert.SerializeObject(networkDonatorDTO);
            else TempData["NetworkDonationReportData"] = null;
            TempData.Keep("NetworkDonationReportData");
            return Partial("_NetworkDonatorsList", networkDonatorDTO);
        }

        public async Task<IActionResult> OnGetExcelDownload()
        {
            int Count = 1;
            NetworkDonatorDTO details = JsonConvert.DeserializeObject<NetworkDonatorDTO>((string)TempData["NetworkDonationReportData"] ?? "{}") ?? new NetworkDonatorDTO();
            TempData.Keep("NetworkDonationReportData");
            if (details.ProductsRequest == null)
            {
                var resultAll = await _networkDonator.GetAllNetworkDonatorAsync(null, null, int.MaxValue, 1);
                details = new NetworkDonatorDTO()
                {
                    PageNumber = PageNumber,
                    PageSize = _appSettingService.Pager_PageSize,
                    ProductsRequest = resultAll.Result.Items.ToList(),
                    TotalCount = resultAll.Result.TotalCount
                };

            }
            var result = details.ProductsRequest.Select(a => new NetworkDonatorReport
            {
                Serial = Count++,
                FullName = a.FullName,
                Email = a.Email,
                MobileNumber = a.MobileNumber,
                TotalDonateAmount = a.TotalDonateAmount,
                TotalDonateCount = a.TotalDonateCount
            }).ToList();
            return new ExcelResult<NetworkDonatorReport>(result, "Sheet1", "NetworkDonatorReport");
        }


    }
}
