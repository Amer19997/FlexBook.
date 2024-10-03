using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Seasons;

namespace WebUI.Pages.Seasons
{
    [Authorize(Roles = SystemRoles.ViewSeasonList + " , " + SystemRoles.SuperAdmin)]

    public class EditModel : PageModel
    {
        private readonly ISeasonsClient _seasonsClient;
        public EditModel(ISeasonsClient seasonsClient)
        {
            _seasonsClient = seasonsClient;
        }
        [BindProperty]
        public SeasonEditModel Season { get; set; }
        public async Task<IActionResult> OnGet(Guid id)
        {
            var result = await _seasonsClient.SeasonsGetAsync(id);
            if (result.Success)
                //Season = _mapper.Map<SeasonEditModel>(result.Result);
                Season = new SeasonEditModel()
                {
                    Id = result.Result.Id,
                    Description = result.Result.Description,
                    EndAt = result.Result.EndAt,
                    NameAr = result.Result.NameAr,
                    NameEn = result.Result.NameEn,
                    StartAt = result.Result.StartAt,
                };
            return Page();
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _seasonsClient.SeasonsPutAsync(new UpdateSeasonCommand()
            {
                Id = Season.Id,
                NameAr = Season.NameAr,
                NameEn = Season.NameEn,
                StartAt = Season.StartAt,
                EndAt = Season.EndAt,
                Description = Season.Description
            });

            return new JsonResult(result);
        }
    }
}
