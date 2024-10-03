using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;

namespace WebUI.Pages.Bank
{
    [Authorize(Roles = SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookUpClient;
        private readonly IAppSettingService _appSettingService;
        public BankDtoPaginatedList Banks { get; set; }
        public IndexModel(ILookUpClient lookUpClient, IAppSettingService appSettingService)
        {
            _lookUpClient = lookUpClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            var result = (await _lookUpClient.GetBanksAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                Banks = result.Result;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            var result = (await _lookUpClient.GetBanksAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_BankList", result.Result);
        }

        public async Task<ActionResult> OnPostDelete(Guid bankId)
        {
            var result = await _lookUpClient.DeleteBankAsync(bankId);
            return new JsonResult(result);
        }
        public async Task<ActionResult> OnPostActivateOrDeactivate(Guid bank_Id)
        {
            var result = await _lookUpClient.ActivateOrDeactivateBankAsync(bank_Id);
            return new JsonResult(result);
        }
    }
}
