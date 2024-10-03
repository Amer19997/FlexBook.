using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Pages.Masarat
{
    [Authorize(Roles = SystemRoles.ViewMasaratList + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        public readonly ILookUpClient _lookUpClient;
        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }
        public List<MasaratItemDto> MasaratListResults { get; set; }

        public IndexModel(IAppSettingService appSettingService, ILookUpClient lookUpClient)
        {
            _appSettingService = appSettingService;
            _lookUpClient = lookUpClient;
            PageSize = _appSettingService.Pager_PageSize;
        }

        public async Task OnGet(int p, string error)
        {
            var result = (await _lookUpClient.GetMasaratListAsync(pageSize: _appSettingService.Pager_PageSize, pageNumber: p == 0 ? 1 : p));
            if (result.Success)
                MasaratListResults = result.Result.MasaratItemDtos.ToList();

            PageNumber = p == 0 ? 1 : p;
            TotalCount = result.Result.TotalCount;

        }
        public async Task OnPost(int? p = 0)
        {
            var result = (await _lookUpClient.GetMasaratListAsync(pageSize: _appSettingService.Pager_PageSize, pageNumber: p == 0 ? 1 : p));
            if (result.Success)
                MasaratListResults = result.Result.MasaratItemDtos.ToList();

            PageNumber = p == 0 ? 1 : p;
            TotalCount = result.Result.TotalCount;
        }

        [HttpPost]
        public async Task<JsonResult> OnPostDeleteMasar(Guid MasarId)
        {
            var GetResult =await _lookUpClient.DeleteMasaratAsync(MasarId);

            return new JsonResult(GetResult);
        }
    }
}
