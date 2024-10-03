using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;

namespace WebUI.Pages.ReportType
{
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookupClient;
        private readonly IAppSettingService _appSettingService;
        public ReportTypeDtoPaginatedList ReportTypes { get; set; }
        public IndexModel(ILookUpClient lookupClient, IAppSettingService appSettingService)
        {
            _lookupClient = lookupClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            var result = (await _lookupClient.GetReportTypesAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                ReportTypes = result.Result;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            var result = (await _lookupClient.GetReportTypesAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_ReportTypeList", result.Result);
        }

        public async Task<ActionResult> OnPostDelete(Guid reportTypeId)
        {
            var result = await _lookupClient.DeleteReportTypeAsync(reportTypeId);
            return new JsonResult(result);
        }
    }
}
