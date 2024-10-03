using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;

namespace WebUI.Pages.Region
{
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookup;
        private readonly IAppSettingService _appSettingService;
        public RegionCmsDtoPaginatedList lookupList { get; set; }
        public IndexModel(ILookUpClient lookUpClient, IAppSettingService appSettingService)
        {
            _lookup = lookUpClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            var result = (await _lookup.GetRegionCmsGetAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                lookupList = result.Result;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            var result = (await _lookup.GetRegionCmsGetAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_RegionList", result.Result);
        }

        public async Task<ActionResult> OnPostDelete(Guid unitId)
        {
            var result = await _lookup.DeleteRegionCmsAsync(unitId);
            return new JsonResult(result);
        }

        public async Task<ActionResult> OnPostHidden(Guid hiddenId)
        {
            var result = await _lookup.HiddenRegionCmsAsync(hiddenId);
            return new JsonResult(result);
        }
    }
}
