using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.AwqafProduct;
using WebUI.Models.Provider;

namespace WebUI.Pages.AwqafProduct
{
    [Authorize(Roles = SystemRoles.ViewAwqafProductRequests + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly IAwqafProductClient _awqafProductClient;
        private readonly IProviderClient _providerClient;
        private readonly IAppSettingService _appSettingService;

        public List<Int32LookupDto> RequestStatus { get; set; }
        [BindProperty(SupportsGet = true)]
        public AwqafProductRequestDtoPaginatedList AwqafProducts { get; set; }
        [BindProperty]
        public AwqafProductSearchModel Filter { get; set; }

        public IndexModel(IAwqafProductClient awqafProductClient, IProviderClient providerClient, IAppSettingService appSettingService)
        {
            _awqafProductClient = awqafProductClient;
            _providerClient = providerClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p, string error)
        {
            var result = (await _awqafProductClient.GetAwqafProductRequestsAsync(null, null,null, _appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                AwqafProducts = result.Result;


            RequestStatus = (await _providerClient.GetProviderRequestStatusAsync()).Result.ToList();

            TempData["SearchFilter"] = null;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filter = JsonConvert.DeserializeObject<AwqafProductSearchModel>((string)TempData["SearchFilter"] ?? "{}") ?? new AwqafProductSearchModel();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filter);

            var result = (await _awqafProductClient.GetAwqafProductRequestsAsync(Filter.DonatorName?.Trim(), Filter.Status, Filter.ProductName?.Trim(), _appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_AwqafProductList", result.Result);
        }
    }
}
