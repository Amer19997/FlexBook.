using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;

namespace WebUI.Pages.Masarat
{
    [Authorize(Roles = SystemRoles.ViewMasaratList + " , " + SystemRoles.SuperAdmin)]
    public class MasaratListModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        public ILookUpClient _lookUpClient { get; set; }
        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }
        public List<MasaratItemDto> MasaratListResults { get; set; }

        public MasaratListModel(IAppSettingService appSettingService, ILookUpClient lookUpClient)
        {
            _appSettingService = appSettingService;
            _lookUpClient = lookUpClient;
            PageSize = _appSettingService.Pager_PageSize;

        }


    }
}
