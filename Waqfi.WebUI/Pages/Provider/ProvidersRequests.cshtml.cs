using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Provider;

namespace WebUI.Pages.Provider
{
    [Authorize(Roles = SystemRoles.ViewProvidersRequestsList + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        private readonly IProviderClient _providerClient;

        public List<Int32LookupDto> ProviderTypes { get; set; }
        public List<Int32LookupDto> ProviderRequestStatus { get; set; }
        [BindProperty(SupportsGet = true)]
        public ProviderRequestDtoPaginatedList Providers { get; set; }
        [BindProperty]
        public ProviderSearchModel Filter { get; set; }
        public IndexModel(IAppSettingService appSettingService,IProviderClient providerClient)
        {
            _appSettingService = appSettingService;
            _providerClient = providerClient;
        }
        public async Task OnGetAsync(int p,string error)
        {
            Error = error;
            var result = (await _providerClient.GetProvidersRequestsQueryAsync(null, null, null, null, null, _appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                Providers=result.Result;

            ProviderTypes = (await _providerClient.GetProviderTypesAsync()).Result.ToList();

            ProviderRequestStatus = (await _providerClient.GetProviderRequestStatusAsync()).Result.ToList();

            TempData["SearchFilter"] = null;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if(p != 0)
                Filter = JsonConvert.DeserializeObject<ProviderSearchModel>((string)TempData["SearchFilter"] ?? "{}") ?? new ProviderSearchModel();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filter);

            var result = (await _providerClient.GetProvidersRequestsQueryAsync(Filter.Name?.Trim(), Filter.Type, Filter.FromDate, Filter.ToDate, Filter.Status, _appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_Providerlist", result.Result);
        }

        
    }
}
