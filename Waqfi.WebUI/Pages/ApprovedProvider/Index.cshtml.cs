using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Provider;

namespace WebUI.Pages.ApprovedProvider
{
    [Authorize(Roles = SystemRoles.ViewProvidersApprovalList + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        private readonly IProviderClient _providerClient;
        private readonly ILookUpClient _lookUpClient;
        public List<Int32LookupDto> ProviderTypes { get; set; }
        public List<GenderItem> GenderType { get; set; }
        public List<Int32LookupDto> ProviderRequestStatus { get; set; }
        [BindProperty(SupportsGet = true)]
        //public ProviderApprovedDtoPaginatedList ProviderApproved { get; set; }
        public ProviderApprovedDtoPaginatedList ProviderApproved { get; set; }

      public ProviderApprovedDtoPaginatedListTResponse Response { get; set; }

        [BindProperty]
        public ProviderApproveSearchModel Filter { get; set; }
        [BindProperty]
        public AssignDueDateRequestCommand DueDateModel { get; set; }

        public IndexModel(IAppSettingService appSettingService, IProviderClient providerClient, ILookUpClient lookUpClient)
        {
            _appSettingService = appSettingService;
            _providerClient = providerClient;
            _lookUpClient = lookUpClient;
        }

        public async Task OnGetAsync(int p, string error)
        {
            Error = error;
            var result = (await _providerClient.GetProvidersApprovedAsync(null, null, null, null, null, null, null, null, _appSettingService.Pager_PageSize, p == 0 ? 1 : p));

            GenderType = (await _lookUpClient.GetServicedGenderListAsync()).Result.ToList();

            if (result.Success)
                
                ProviderApproved = result.Result;

            ProviderTypes = (await _providerClient.GetProviderTypesAsync()).Result.ToList();
            TempData["SearchFilter"] = null;
        }


        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filter = JsonConvert.DeserializeObject<ProviderApproveSearchModel>((string)TempData["SearchFilter"] ?? "{}") ?? new ProviderApproveSearchModel();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filter);

            var result = (await _providerClient.GetProvidersApprovedAsync(Filter.Name?.Trim(), Filter.RegisterNum?.Trim(), Filter.Type, Filter?.Gender, Filter.JoinFromDate, Filter.JoinToDate,
                                                                            null, null, _appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_ProviderApproveList", result.Result);
        }
        public async Task<JsonResult> OnPostDueDate()
        {
            var result = await _providerClient.AssignProvidersDueDateAsync(DueDateModel);
            return new JsonResult(result);
        }

        public async Task<JsonResult> OnPostChangeActivation(string providerId, bool isActive)
        {
            var GetResult = await _providerClient.ChangeActivationProviderAsync(providerId);

            return new JsonResult(GetResult);
        }
    }
}
