using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;

namespace WebUI.Pages.SecondSubclass
{
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookup;
        private readonly IAppSettingService _appSettingService;
        public SecondSubclassCmsDtoPaginatedList lookupList { get; set; }
        public IndexModel(ILookUpClient lookUpClient, IAppSettingService appSettingService)
        {
            _lookup = lookUpClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            var result = (await _lookup.GetSecondSubclassclassCmsAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                lookupList = result.Result;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            var result = (await _lookup.GetSecondSubclassclassCmsAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_SecondSubclassList", result.Result);
        }

        public async Task<ActionResult> OnPostDelete(Guid unitId)
        {
            var result = await _lookup.DeleteSecondSubclassclassCmsAsync(unitId);
            return new JsonResult(result);
        }

    }
}
