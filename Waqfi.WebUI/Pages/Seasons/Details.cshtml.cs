using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Seasons;

namespace WebUI.Pages.Seasons
{
    [Authorize(Roles = SystemRoles.ViewSeasonList + " , " + SystemRoles.SuperAdmin)]
    public class DetailsModel : PageModel
    {
        private readonly ISeasonsClient _seasonsClient;
        public DetailsModel(ISeasonsClient seasonsClient)
        {
            _seasonsClient = seasonsClient;
        }
        [BindProperty(SupportsGet = true)]
        public SeasonEditModel Season { get; set; }
        public async Task<IActionResult> OnGet(Guid id)
        {
            var result = await _seasonsClient.SeasonsGetAsync(id);
            if (result.Success)
                Season = new SeasonEditModel()
                {
                    Id = result.Result.Id,
                    Description = result.Result.Description,
                    EndAt = result.Result.EndAtHijry,
                    NameAr = result.Result.NameAr,
                    NameEn = result.Result.NameEn,
                    StartAt = result.Result.StartAtHijry,
                };
            return Page();
        }
    }
}
