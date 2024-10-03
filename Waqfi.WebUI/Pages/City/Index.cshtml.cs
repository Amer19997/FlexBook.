using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;

namespace WebUI.Pages.City
{
   // [Authorize(Roles = SystemRoles.ViewCityList + " , " + SystemRoles.SuperAdmin)]

    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookup;
        private readonly IAppSettingService _appSettingService;
        public CityCmsDtoPaginatedList lookupList { get; set; }
        public IndexModel(ILookUpClient lookUpClient, IAppSettingService appSettingService)
        {
            _lookup = lookUpClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            var result = (await _lookup.GetCityCmsGetAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                lookupList = result.Result;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            var result = (await _lookup.GetCityCmsGetAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_CityList", result.Result);
        }

        public async Task<ActionResult> OnPostDelete(Guid unitId)
        {
            var result = await _lookup.DeleteCityCmsAsync(unitId);
            return new JsonResult(result);
        }

        public async Task<ActionResult> OnPostHidden(Guid hiddenId)
        {
            var result = await _lookup.HiddenCityCmsAsync(hiddenId);
            return new JsonResult(result);
        }

    }
}
