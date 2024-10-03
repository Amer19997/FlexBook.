using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Seasons;

namespace WebUI.Pages.Seasons
{
    [Authorize(Roles = SystemRoles.ViewSeasonList + " , " + SystemRoles.SuperAdmin)]

    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        private readonly ISeasonsClient _seasonsClient;

        [BindProperty(SupportsGet = true)]
        public GetSeasonsResultPaginatedList GetSeasons { get; set; }

        [BindProperty]
        public SeasonsViewModal Filter { get; set; }

        public IndexModel(ISeasonsClient seasonsClient, IAppSettingService appSettingService)
        {
            _seasonsClient = seasonsClient;
            _appSettingService = appSettingService;
        }

        public async Task OnGetAsync(int p, string error)
        {
            Error = error;
            var result = (await _seasonsClient.SeasonsGetAsync(null, _appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                GetSeasons = result.Result;

            TempData["SearchFilter"] = null;
        }


        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filter = JsonConvert.DeserializeObject<SeasonsViewModal>((string)TempData["SearchFilter"] ?? "{}") ?? new SeasonsViewModal();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filter);

            var result = (await _seasonsClient.SeasonsGetAsync(Filter.Name?.Trim(), _appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_Seasonlist", result.Result);
        }
        public async Task<ActionResult> OnPostDelete(Guid seasonId)
        {
            var result = await _seasonsClient.SeasonsDeleteAsync(seasonId);
            return new JsonResult(result);
        }
    }
}
